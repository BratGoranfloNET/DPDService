using BG.Core.Utilities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

public static class CoreExtensions
{
	/// <summary>
	/// Convert data between different known types.
	/// </summary>
	public static T ChangeType<T>(this object @this, T defaultValue = default(T))
	{
		try
		{
			if (@this == null)
				return defaultValue;

			if (@this is T)
				return (T)@this;

			if (typeof(T).IsEnum)
			{
				// If is multiple word, consider a slugged value.
				// Attempt to convert it back by applying the same process with no sepparator.
				var enumStr = @this.ToString().FilterSpecialChars(replacer: string.Empty);

				return (T)Enum.Parse(typeof(T), enumStr, ignoreCase: true);
			}

			Type conversionType = typeof(T);

			// Nullables
			if (conversionType.IsGenericType && conversionType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
			{
				if (@this == null)
					return defaultValue;

				conversionType = (new NullableConverter(conversionType)).UnderlyingType;
			}

			// Bool
			if (conversionType.Equals(typeof(bool)))
				return (T)((object)Convert.ToBoolean(@this));

			// Datetime
			if (conversionType.Equals(typeof(DateTime)))
				return (T)((object)DateTime.Parse(@this.ToString(), CultureInfo.CurrentCulture));

			// TimeSpan
			if (conversionType.Equals(typeof(TimeSpan)))
				return (T)((object)TimeSpan.Parse(@this.ToString(), CultureInfo.CurrentCulture));

			return (T)Convert.ChangeType(@this, conversionType);
		}
		catch
		{
			return defaultValue;
		}
	}

	public static string RemoveControllerSuffix(this string @this)
	{
		if (@this.IsNullOrWhiteSpace())
			return string.Empty;

		return @this.Substring(
			0,
			@this.LastIndexOf("Controller", StringComparison.InvariantCultureIgnoreCase)
		);
	}

	/// <summary>
	/// Attempts to get the enum name from the display attribute or returns the enum value as string.
	/// </summary>
	public static string GetDisplayName(this Enum enumValue)
	{
		if (enumValue == null)
			return string.Empty;

		var display = enumValue.GetType().GetMember(enumValue.ToString()).FirstOrDefault()?.GetCustomAttribute<DisplayAttribute>() ?? null;

		if (display != null)
			return display.GetName();

		return enumValue.ToString();
	}

	/// <summary>
	/// Ensures that null strings will become string.Empty.
	/// </summary>
	public static string EnsureNotNull(this string @this)
	{
		return @this ?? string.Empty;
	}

	/// <summary>
	/// Compare strings ignoring culture and casing.
	/// </summary>
	public static bool Like(this string @this, string compareTo, bool compareNull = false)
	{
		if (@this == null || compareTo == null)
		{
			if (compareNull)
				return @this == compareTo;

			return false;
		}

		return @this.Trim().Equals(compareTo.Trim(), StringComparison.InvariantCultureIgnoreCase);
	}

	/// <summary>
	/// Return the input string as a normalized ASCII string without any accentuation.
	/// </summary>
	public static string NormalizeAccentuation(this string @this)
	{
		if (string.IsNullOrWhiteSpace(@this))
			return string.Empty;

		var stringBuilder = new StringBuilder();
		var normalizedString = @this.Normalize(NormalizationForm.FormD);

		foreach (var c in normalizedString)
		{
			var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);

			if (unicodeCategory != UnicodeCategory.NonSpacingMark)
				stringBuilder.Append(c);
		}

		return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
	}

	/// <summary>
	/// Replaces any non alphanumeric chars by the specified replacer.
	/// </summary>
	public static string FilterSpecialChars(this string @this, string replacer)
	{
		if (string.IsNullOrWhiteSpace(@this))
			return string.Empty;

		if (string.IsNullOrEmpty(replacer))
			replacer = string.Empty;

		return RegularExpressions.SpecialChars.Replace(@this, replacer);
	}

	/// <summary>
	/// Converts a camel cased enum value to a slug.
	/// </summary>
	/// <param name="source"></param>
	/// <returns></returns>
	public static string ToSlug(this Enum enumValue, string wordSepparator = "-")
	{
		if (enumValue == null)
			return string.Empty;

		var enumString = RegularExpressions.UpperCase.Replace(enumValue.ToString(), " ");

		return enumString.ToSlug(wordSepparator);
	}

	/// <summary>
	/// Converts the input string to a normalized, non accentuated URL/SEO friendly string.
	/// </summary>
	public static string ToSlug(this string @this, string wordSepparator = "-")
	{
		if (string.IsNullOrWhiteSpace(@this))
			return @this;

		var normalized = @this.NormalizeAccentuation().ToLower();
		var filtered = normalized.FilterSpecialChars(replacer: " ");

		var slug = RegularExpressions.MultiWhiteSpaces.Replace(filtered, wordSepparator);

		return slug.Trim(wordSepparator.ToCharArray());
	}

	/// <summary>
	/// Truncates the input string on the specified length.
	/// </summary>
	public static string Truncate(this string @this, int length, string suffix = null)
	{
		if (string.IsNullOrEmpty(@this))
			return string.Empty;

		if (string.IsNullOrWhiteSpace(suffix))
			suffix = string.Empty;

		int inputLen = @this.Length;

		if (inputLen <= length)
			return @this;

		int breakPosition = @this.IndexOf("\n");

		if (breakPosition < 0)
			breakPosition = @this.IndexOf(".");

		if (breakPosition < 0 || breakPosition > length)
			breakPosition = length;

		int suffixSize = suffix.Length;

		if (breakPosition < 0)
			return string.Concat(@this.Substring(0, inputLen - suffixSize), suffix);

		if (breakPosition > @this.Length)
			breakPosition = @this.Length;

		breakPosition = breakPosition - suffixSize;

		return string.Concat(@this.Substring(0, breakPosition).Trim(), suffix);
	}

	/// <summary>
	/// Indicates whether a specified string is null, empty, or consists only of white-space characters.
	/// </summary>
	public static bool IsNullOrWhiteSpace(this string @this)
	{
		return string.IsNullOrWhiteSpace(@this);
	}

	/// <summary>
	/// Returns a placeholder text when the string is null, empty, or consists only of white-space characters.
	/// </summary>
	public static string WhenNullOrWhiteSpace(this string @this, string placeholderText)
	{
		if (@this.IsNullOrWhiteSpace())
			return placeholderText.EnsureNotNull();

		return @this;
	}

	/// <summary>
	/// Indicates whether the specified string is null or an <see cref="string.Empty"/> string.
	/// </summary>
	public static bool IsNullOrEmpty(this string @this)
	{
		return string.IsNullOrEmpty(@this);
	}

	/// <summary>
	/// Returns a placeholder text when the string is null or an <see cref="string.Empty"/> string.
	/// </summary>
	public static string WhenNullOrEmpty(this string @this, string placeholderText)
	{
		if (@this.IsNullOrEmpty())
			return placeholderText.EnsureNotNull();

		return @this;
	}

	/// <summary>
	/// Converts the object value to a lower case string.
	/// </summary>
	public static string ToLowerCaseString(this object @this)
	{
		if (@this == null)
			return string.Empty;

		return @this.ToString().ToLower();
	}

	/// <summary>
	/// Converts the object value to an upper case string.
	/// </summary>
	public static string ToUpperCaseString(this object @this)
	{
		if (@this == null)
			return string.Empty;

		return @this.ToString().ToUpper();
	}

	public static string ToByteSizeLabel(this long @this, string format = "#.#")
	{
		return ByteSize.FromBytes(@this).ToString(format);
	}
}

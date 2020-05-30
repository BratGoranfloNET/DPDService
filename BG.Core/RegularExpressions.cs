using System.Text.RegularExpressions;

/// <summary>
/// Commonly used regular expressions and patterns.
/// </summary>
public static class RegularExpressions
{
	public const string UpperCasePattern = @"(?<!^)(?=[A-Z])";
	public static readonly Regex UpperCase = new Regex(UpperCasePattern, RegexOptions.Compiled);

	public const string SimpleEmailPattern = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
	public static readonly Regex SimpleEmail = new Regex(SimpleEmailPattern, RegexOptions.Compiled);

	public const string SpecialCharsPattern = @"[^a-zA-Z0-9]";
	public static readonly Regex SpecialChars = new Regex(SpecialCharsPattern, RegexOptions.Compiled);

	public const string UserNamePattern = @"^[a-zA-Z][a-zA-Z0-9]+$";
	public static readonly Regex UserName = new Regex(UserNamePattern, RegexOptions.Compiled);

	public const string MultiWhiteSpacesPattern = @"\s+";
	public static readonly Regex MultiWhiteSpaces = new Regex(MultiWhiteSpacesPattern, RegexOptions.Compiled);
}

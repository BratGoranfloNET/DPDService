using FluentValidation;
using BG.Core.Context;
using BG.Core.Entities;
using BG.Core.Repositories;
using BG.Core.Resources;
using System;

namespace BG.Web.UI.Models
{
	/// <summary>
	/// User view model validator.
	/// </summary>
	public class UserViewModelValidator : AbstractValidator<UserViewModel>
	{
		private IWebContext _context = null;
		private IBlobsRepository _blobsRepository = null;
		private IUsersRepository _usersRepository = null;

		/// <summary>
		/// Constructor method.
		/// </summary>
		public UserViewModelValidator(IWebContext context, IBlobsRepository blobsRepository, IUsersRepository usersRepository)
		{
			_context = context;
			_blobsRepository = blobsRepository;
			_usersRepository = usersRepository;

			// Name
			RuleFor(model => model.Name).NotEmpty();
			RuleFor(model => model.Name).Length(0, User.NameMaxLength).WithLocalizedMessage(() => FluentValidationResources.MaxLength);

			// Email
			RuleFor(model => model.Email).NotEmpty();
			RuleFor(model => model.Email).Matches(RegularExpressions.SimpleEmailPattern);
			RuleFor(model => model.Email).Length(0, User.EmailMaxLength).WithLocalizedMessage(() => FluentValidationResources.MaxLength);
			RuleFor(model => model.Email).Must(BeUniqueOrCurrentEmail).WithLocalizedMessage(() => FluentValidationResources.UserUniqueFieldError);

			// Username
			RuleFor(model => model.UserName).NotEmpty();
			RuleFor(model => model.UserName).Matches(RegularExpressions.UserNamePattern);
			RuleFor(model => model.UserName).Length(0, User.UsernameMaxLength).WithLocalizedMessage(() => FluentValidationResources.MaxLength);
			RuleFor(model => model.UserName).Must(BeUniqueOrCurrentUsername).WithLocalizedMessage(() => FluentValidationResources.UserUniqueFieldError);

			// Image Blob Id
			RuleFor(model => model.ImageBlobId).Must(BeExistingImageBlobId).WithLocalizedMessage(() => FluentValidationResources.BlobIdInvalidError);

			// Social media
			RuleFor(model => model.GitHubLink).Matches(@"https?://.*github.*").WithLocalizedMessage(() => FluentValidationResources.AbsoluteLinkError);
			RuleFor(model => model.TwitterLink).Matches(@"https?://.*twitter.*").WithLocalizedMessage(() => FluentValidationResources.AbsoluteLinkError);
			RuleFor(model => model.LinkedInLink).Matches(@"https?://.*linkedin.*").WithLocalizedMessage(() => FluentValidationResources.AbsoluteLinkError);
			RuleFor(model => model.FacebookLink).Matches(@"https?://.*facebook.*").WithLocalizedMessage(() => FluentValidationResources.AbsoluteLinkError);
			RuleFor(model => model.InstagramLink).Matches(@"https?://.*instagram.*").WithLocalizedMessage(() => FluentValidationResources.AbsoluteLinkError);

			// Globalization
			RuleFor(model => model.CurrentCultureId).NotEmpty();
			RuleFor(model => model.CurrentUICultureId).NotEmpty();
			RuleFor(model => model.TimeZoneId).NotEmpty();

			// Auto lock screen
			RuleFor(model => model.AutoLockScreenInMinutes).Must(BeValidInterval);

			// Status Message
			RuleFor(model => model.StatusMessageUpdate).Length(0, User.StatusMessageMaxLength).WithLocalizedMessage(() => FluentValidationResources.MaxLength);
		}

		/// <summary>
		/// Checks if the provided e-mail is unique or already belongs to the current user.
		/// </summary>
		private bool BeUniqueOrCurrentEmail(string email)
		{
			if (string.IsNullOrWhiteSpace(email))
				return false;

			var user = _usersRepository.GetByEmail(email);

			if (user == null)
				return true;

			if (_context == null)
				return false;

			return user.Id.Equals(_context.User.Id);
		}

		/// <summary>
		/// Checks if the provided username is unique or already belongs to the current user.
		/// </summary>
		private bool BeUniqueOrCurrentUsername(string userName)
		{
			if (string.IsNullOrWhiteSpace(userName))
				return false;

			var user = _usersRepository.GetByUserName(userName);

			if (user == null)
				return true;

			if (_context == null)
				return false;

			return user.Id.Equals(_context.User.Id);
		}

		/// <summary>
		/// Checks if the provided image id belongs to a valid blob.
		/// </summary>
		private bool BeExistingImageBlobId(Guid? imageBlobId)
		{
			if (!imageBlobId.HasValue)
				return true;

			var imageBlob = _blobsRepository.GetById(imageBlobId.Value);

			return imageBlob != null;
		}

		/// <summary>
		/// Simply check if the provided link is a valid http(s) URI.
		/// </summary>
		private bool BeAValidSocialMediaLink(string socialMediaLink)
		{
			Uri socialMediaUri;

			if (socialMediaLink.IsNullOrWhiteSpace())
				return true;

			if (Uri.TryCreate(socialMediaLink, UriKind.Absolute, out socialMediaUri))
				return socialMediaUri.Scheme == Uri.UriSchemeHttp || socialMediaUri.Scheme == Uri.UriSchemeHttps;

			return false;
		}

		private bool BeValidInterval(byte autoLockScreenInMinutes)
		{
			return autoLockScreenInMinutes >= 0 && autoLockScreenInMinutes <= User.AutoLockScreenMaxMinutes;
		}
	}
}

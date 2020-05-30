using BG.Core.Entities;
using System;
using System.Collections.Generic;

namespace BG.Core.Repositories
{
	/// <summary>
	/// Blobs repository interface.
	/// </summary>
	public interface IBlobsRepository
	{
		/// <summary>
		/// Create an entity.
		/// </summary>
		Blob Create(Blob blobEntity);

		/// <summary>
		/// Get entities.
		/// </summary>
		IEnumerable<Blob> GetAll();

		/// <summary>
		/// Get an entity.
		/// </summary>
		Blob GetById(Guid entityId);

		/// <summary>
		/// Delete an entity.
		/// </summary>
		void Delete(Guid entityId);
	}
}

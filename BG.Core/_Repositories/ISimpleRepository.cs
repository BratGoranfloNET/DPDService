using System.Collections.Generic;

namespace BG.Core.Repositories
{
	/// <summary>
	/// Simple CRUD repository interface.
	/// </summary>
	public interface ISimpleRepository<TEntity> : ISimpleRepository<TEntity, int> { }

	/// <summary>
	/// Simple CRUD repository interface.
	/// </summary>
	public interface ISimpleRepository<TEntity, TEntityId>
	{
		/// <summary>
		/// Create an entity.
		/// </summary>
		TEntity Create(TEntity entity);

		/// <summary>
		/// Get entities.
		/// </summary>
		IEnumerable<TEntity> GetAll();

		/// <summary>
		/// Get an entity by id.
		/// </summary>
		TEntity GetById(TEntityId entityId);

		/// <summary>
		/// Update an entity.
		/// </summary>
		TEntity Update(TEntity entity);

		/// <summary>
		/// Delete an entity.
		/// </summary>
		void Delete(TEntityId entityId);       

    }
}

using Dapper;
using DapperExtensions;
using PreUni.Core.ConnectionFactory;
using PreUni.Core.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PreUni.OnlineTest.DAL.Repository
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, new()
    {

        #region ==Properties==

        protected IPreUniOnlineConnectionFactory _connectionFactory;

        private IEnumerable<PropertyInfo> GetProperties => typeof(TEntity).GetProperties();

        private string ModelName; 

        #endregion


        #region ==Contructor==

        public GenericRepository(IPreUniOnlineConnectionFactory _connectionFactory)
        {
            this._connectionFactory = _connectionFactory;
            ModelName = typeof(TEntity).Name;
        }

        #endregion


        #region ==Public Methods==
        public Task<TEntity> GetAsync(int Id)
        {
            var connection = _connectionFactory.GetConnection;

            var id = ModelName + "ID";

            var resultTask = connection.QuerySingleOrDefaultAsync<TEntity>($"SELECT * FROM {ModelName} WHERE {id}=@Id", new { Id = Id });

            return resultTask;
        }

        public Task<IEnumerable<TEntity>> GetPartiallyAsync(int Id)
        {
            var connection = _connectionFactory.GetConnection;

            var id = ModelName + "ID";

            var resultTask = connection.QueryAsync<TEntity>($"SELECT * FROM {ModelName} WHERE {id}=@Id", new { Id = Id });

            return resultTask;
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var connection = _connectionFactory.GetConnection;

            return connection.QueryAsync<TEntity>($"SELECT * FROM {ModelName}");
        }

        public async Task<int> SaveRangeAsync(IEnumerable<TEntity> list)
        {
            var inserted = 0;
            var query = GenerateInsertQuery();
            using (var connection = _connectionFactory.GetConnection)
            {
                inserted += await connection.ExecuteAsync(query, list);
            }

            return inserted;
        }

        public Task InsertAsync(TEntity t)
        {
            return Task.Run(() =>
           {
               var insertQuery = GenerateInsertQuery();

               var connection = _connectionFactory.GetConnection;
               connection.ExecuteAsync(insertQuery, t);
           });
        }

        public Task DeleteAsync(int Id)
        {
            return Task.Run(() =>
            {
                var connection = _connectionFactory.GetConnection;
                var id = ModelName + "ID";
                connection.ExecuteAsync($"DELETE FROM {ModelName} WHERE {id}= @Id", new { Id = Id });
            });
        }

        public Task DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, object>> expression, object value)
        {
            var connection = _connectionFactory.GetConnection as SqlConnection;

            var predicate = Predicates.Field<TEntity>(expression, Operator.Eq, value);

            return connection.GetList<TEntity>(predicate);
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> condition)
        {
            throw new NotImplementedException();
        }

        #endregion


        #region ==Helpers==
        private string GenerateInsertQuery()
        {
            var insertQuery = new StringBuilder($"INSERT INTO {ModelName} ");

            insertQuery.Append("(");

            List<string> properties = GenerateListOfProperties(GetProperties);

            properties.ForEach(prop => { insertQuery.Append($"[{prop}],"); });

            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(") VALUES (");

            properties.ForEach(prop => { insertQuery.Append($"@{prop},"); });

            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(")");

            return insertQuery.ToString();
        }

        private List<string> GenerateListOfProperties(IEnumerable<PropertyInfo> listOfProperties)
        {
            var idName = ModelName + "ID";

            return (from prop in listOfProperties
                    let attributes = prop.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    where attributes.Length <= 0 || (attributes[0] as DescriptionAttribute)?.Description != "ignore"
                    where prop.Name != idName
                          && !prop.PropertyType.GetTypeInfo().IsGenericType
                          || prop.GetType() == typeof(int)
                          || prop.GetType() == typeof(DateTime)
                          || prop.GetType() == typeof(string)
                    select prop.Name).ToList();
        }

        public Task DeleteRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}

using System;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Helper
{
    public class DapperHelper
    {
		private readonly string connStr;

		public class Result
		{
			public Result(int affectedRows, string success, string responseCode)
			{
				AffectedRows = affectedRows;
				Success = success ?? string.Empty;
				ResponseCode = responseCode ?? string.Empty;
			}

			public int AffectedRows { get; private set; }
			public string Success { get; private set; }
			public string ResponseCode { get; private set; }
		}

		public DapperHelper(string connStr)
		{
			this.connStr = connStr;
			Dapper.SqlMapper.Settings.CommandTimeout = 0;
		}

		public Result QueryMultiple(string spName, object parameters, Action<SqlMapper.GridReader> readFromResult)
		{
			if (string.IsNullOrEmpty(spName))
			{
				throw new ArgumentException("message", nameof(spName));
			}

			using (var conn = new SqlConnection(connStr))
			{
				var reader = conn.QueryMultiple(spName, parameters, commandType: CommandType.StoredProcedure);

				readFromResult?.Invoke(reader);

				return new Result(1, "", "");
			}
		}

		public Result Execute(string spName, object parameters)
		{
			if (string.IsNullOrEmpty(spName))
			{
				throw new ArgumentException("message", nameof(spName));
			}

			using (var conn = new SqlConnection(connStr))
			{
				int recordCount = conn.Execute(spName, parameters, commandType: CommandType.StoredProcedure);
				return new Result(
					recordCount
					, ""
					, ""
				);
			}
		}
	}
}

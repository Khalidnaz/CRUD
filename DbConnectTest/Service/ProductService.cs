
using DbConnect.Adapter;
using DbConnect.Tools;
using DbConnectTest.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConnectTest.Service
{
    public class ProductService
    {
        private IDbAdapter Adapter
        {
            get
            {
                return new DbAdapter(new SqlCommand(), new SqlConnection("Server=13.64.246.7;Database=C41_OrganicKarma;User Id=C41_User;Password=Sabiopass1!"));
            }
        }

        public IEnumerable<Products> GetAllProducts()
        {
            DbCmdDef cmdDef = new DbCmdDef
            {
                DbCommandText = "dbo.Product_SelectAll",
                DbCommandType = System.Data.CommandType.StoredProcedure,
                DbParameters = new[]
                {
                    SqlDbParameter.Instance.BuildParameter<bool>("@DisplayActive", true, System.Data.SqlDbType.Bit)
                }
            };
            return Adapter.LoadObject<Products>(cmdDef);
        }

        public Products GetById(int id)
        {
            try
            {
                return Adapter.LoadObject<Products>(new DbCmdDef
                {
                    DbCommandText = "dbo.Product_SelectById",
                    DbCommandType = System.Data.CommandType.StoredProcedure,
                    DbParameters = new[]
                    {
                        SqlDbParameter.Instance.BuildParameter("@Id", id, System.Data.SqlDbType.Int)
                    }
                }).FirstOrDefault();
            }
            catch { throw; }
        }
    }
}

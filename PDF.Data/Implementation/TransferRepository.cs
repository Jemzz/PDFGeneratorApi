using Dapper;
using Microsoft.Extensions.Options;
using System.Data;
using System.Threading.Tasks;
using PDF.Data.Entities.ISATransfer;
using PDF.Data.Interface;

namespace PDF.Data.Implementation
{
    public class TransferRepository : RepositoryBase, ITransferRepository
    {
        public TransferRepository(IOptions<RepositoryOptions> configuration) : base(configuration)
        {
        }

        public async Task<ISATransferData> GetISATransferData(int isaTransferId)
        {
            using var cn = Connection;
            const string sql = "reporting.IsaTransferReport_Read";

            return await cn.QueryFirstOrDefaultAsync<ISATransferData>(sql, new
            {
                isaTransferId
            }, commandType: CommandType.StoredProcedure);
        }
    }
}

using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class AddBalanceEntityModel
    {
        public int id { get; set; }

        public int? idClient { get; set; }
        public int? SumForAdd { get; set; }
        public string phoneNumberForAddBalance { get; set; }

        public string numberBankCard { get; set; }

        public string nameBankCard { get; set; }

        public DateTime? dateBankCard { get; set; }

        public int? CVVBankCard { get; set; }
        public AddBalanceEntityModel()
        {

        }
        public AddBalanceEntityModel(AddBalance addBalance)
        {
            id = addBalance.id;
            idClient = addBalance.idClient;
            SumForAdd = addBalance.SumForAdd;
            phoneNumberForAddBalance = addBalance.phoneNumberForAddBalance;
            numberBankCard = addBalance.numberBankCard;
            nameBankCard = addBalance.nameBankCard;
            dateBankCard = addBalance.dateBankCard;
            CVVBankCard = addBalance.CVVBankCard;
        }
    }
}

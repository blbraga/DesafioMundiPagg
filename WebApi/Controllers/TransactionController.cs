using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Desafio.Controllers;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;
using Domain;
using System.IO;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TransactionController : CustomController
    {
        // GET api/transaction
        [HttpGet]
        public string Get(string key)
        {
            var lst = new List<Transaction>();
            var url = "https://sandbox.mundipaggone.com/Sale";
            var i = 1;

            using (var reader = new StreamReader(@"d:\arquivo.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    var creditCard = new CreditCardTransaction()
                    {
                        AmountInCents = Convert.ToInt32(values[1].Replace(".", string.Empty)),
                        CreditCard = new CreditCard()
                        {
                            CreditCardBrand = (CreditCardBrandEnum)System.Enum.Parse(typeof(CreditCardBrandEnum), values[2]),
                            CreditCardNumber = values[3],
                            ExpMonth = Convert.ToInt32(values[4]),
                            ExpYear = Convert.ToInt32(values[5]),
                            HolderName = values[6],
                            SecurityCode = values[7]
                        },
                        InstallmentCount = 1
                    };

                    var obj = new Transaction() { Priority = (PriorityEnum)Convert.ToInt32(values[0]), FileOrder = i };
                    obj.CreditCardTransactionCollection.Add(creditCard);
                    lst.Add(obj);

                    i++;
                }
            }

            foreach (var obj in lst.OrderByDescending(x => x.Priority))
            {
                var result = Gateway(key, obj, url);
                result.Priority = obj.Priority;
                result.FileOrder = obj.FileOrder;

                lst[lst.IndexOf(obj)] =  result;
            }

            return JsonConvert.SerializeObject(lst.OrderByDescending(x => x.Priority)); ;
        }
        
    }
}

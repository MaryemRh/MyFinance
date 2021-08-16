using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Facture
    {
        [Key(),Column(Order =0)]
        [DataType(DataType.Date)]
        public DateTime DateAchat { get; set; }
        public float Prix { get; set; }

        [Key(), Column(Order = 1)]
        [ForeignKey("Product")]
        public int Productid { get; set; }
        public Product Product { get; set; }
        [Key, Column(Order = 2)]
        [ForeignKey("Client")]
        
        public int ClientId { get; set; }
        public Client Client { get; set; }


    }
}

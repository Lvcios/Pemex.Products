using PetaPoco;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pemex.Products.DAL.Model.Advertisement
{
    [TableName("advertisement")]
    [PrimaryKey("id")]
    public class Advertisement
    {
        [Column("id")]
        public Guid Id { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("type_ad")]
        public string Type { get; set; }
        [Column("price")]
        public decimal Price { get; set; }
        [Column("image")]
        public byte[] Image { get; set; }
        [Column("creation_date")]
        public DateTime CreationDate { get; set; }
    }
}

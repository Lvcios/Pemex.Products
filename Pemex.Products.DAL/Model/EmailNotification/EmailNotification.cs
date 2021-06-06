using PetaPoco;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pemex.Products.DAL.Model.EmailNotification
{
    [TableName("email_notification")]
    [PrimaryKey("id")]
    public class EmailNotification
    {
        [Column("id")]
        public Guid Id { get; set; }
        [Column("name_from")]
        public string NameFrom { get; set; }
        [Column("email_from")]
        public string EmailFrom { get; set; }
        [Column("email_to")]
        public string EmailTo { get; set; }
        [Column("name_to")]
        public string NameTo { get; set; }
        [Column("subject")]
        public string Subject { get; set; }
        [Column("message")]
        public string Message { get; set; }
        [Column("sent")]
        //Si la idea es encolar los correos en un background job entonces necesitamos saber si ya fue enviado
        public bool Sended { get; set; }
        [Column("creation_date")]
        public DateTime CreationDate { get; set; }
        //Fecha en que se realizó el envio
        [Column("sent_date")]
        public DateTime SentDate{ get; set; }
    }
}

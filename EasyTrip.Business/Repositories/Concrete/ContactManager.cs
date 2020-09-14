using EasyTrip.Business.Repositories.Abstract;
using EasyTrip.DataAccess.Abstract;
using EasyTrip.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EasyTrip.Business.Repositories.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal contactDal;
        public ContactManager(IContactDal _contactDal)
        {
            contactDal = _contactDal;
        }
        public bool Delete(Contact model)
        {
            try
            {
                return contactDal.Delete(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Contact Get(Expression<Func<Contact, bool>> filter, params string[] includeList)
        {
            try
            {
                return contactDal.Get(filter, includeList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Contact> GetList(Expression<Func<Contact, bool>> filter = null, params string[] includeList)
        {
            try
            {
                return contactDal.GetList(filter, includeList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert(Contact model)
        {
            try
            {
                return contactDal.Insert(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SendMessage(Contact model)
        {
            try
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Credentials = new NetworkCredential("xxxxxxx@hotmail.com","xxxx");
                smtp.Port = 587;
                smtp.Host = "smtp.live.com";
                smtp.EnableSsl = true;

                MailMessage mail = new MailMessage();
                mail.To.Add(model.Email);
                mail.From = new MailAddress("xxxxxxx@hotmail.com");
                mail.Subject = "Bize ulaşın sayfasından mesajınız var.";
                mail.Body = "<table style='background-color:#fff;padding:10px;width:620px;text-align:left;border-top:10px solid #333333;" +
                    "border-bottom:10px solid #333333;border-left:10px solid #333333;border-right:10px solid #333333'" +
                    " width='630' cellspacing='0' cellpadding='0'><tbody>" +
                    "<tr><td>" +
                    "<table style='background-color:#ffffff;' width='100%' cellspacing='0' cellpadding = '0'>  <tbody><tr><td style = 'padding: 10px;'>" +

                    "<td style = 'color: #1a2640; font-family: Arial; font-size: 13px;margin-left:50px;' align = 'right' > (0505) 282 01 97 " +
                    "<span style = 'color: #a5b9c5; font-size: 24px;' >|</span> " +
                    "<a style = 'text-decoration: none; color: #1a2640;' href = 'http://www.easytravelguide.somee.com/' target = '_blank' data - saferedirecturl = '#'>" +
                    "www.easytravelguide.somee.com </a> &nbsp; &nbsp; &nbsp;</td></tr>" +
                    "<tr><td colspan = '2' ><hr style='border: 1px dashed black;'/> </td></tr><tr><td style = 'padding: 10px; font-size: 12px; font-family: Arial;' colspan = '2' >" +
                    "<p style = 'margin: 0 0 10px 0;' > Gönderen: <strong>" + model.FullName + "</strong>,</p>" +
                    "<p style = 'margin: 0 0 10px 0;' > Email: <strong>" + model.Email + "</strong>,</p>" +
                    "<p style = 'margin: 0 0 10px 0;' > Konu: <strong>" + mail.Subject + "</strong>,</p>" +
                    "<p style = 'margin: 0 0 10px 0;' > Mesaj: <strong>" + model.Message + "</strong>,</p> <br /> <br />" +
                    "<p style = 'margin: 0 0 0 0;' >" +
                    "Her türlü sorunuzda bize " +
                    "<a style = 'color: #000000;' href = 'mailto:'" + smtp.Host + "target = '_blank'> " + smtp.Host + " </a> " +
                    "adresinden ulaşabilir veya " +
                    "<a href = 'tel:(505) 282 01 97' target = '_blank' > (0505) 282 01 97 </a> nolu telefondan görüşebilirsiniz.</p>" +
                    "<p style = 'margin: 20px 0 0 0;' > Saygılarımızla,</p><p style = 'margin: 5px 0 0 0;' > " +
                    "Halis Tascigul | Software Developer</p></td></tr>" +
                    "<tr><td colspan = '2' ><hr style='border: 1px dashed black;'/></td></tr><tr><td style = 'padding: 10px; color: #808080; font-size: 12px;' colspan = '2'>" +
                    "<p style = 'margin: 0 0 0 0; font-family: Arial;' >" +
                    " Copyright &copy; 2020 Halis Tascigul | Tüm hakları saklıdır.</p></td></tr></tbody></table></td></tr></tbody></table> ";
                mail.IsBodyHtml = true;
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Contact model)
        {
            try
            {
                return contactDal.Update(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

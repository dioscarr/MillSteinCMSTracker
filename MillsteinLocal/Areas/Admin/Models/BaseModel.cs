using System;
using DAL.Models;
using BLL;

namespace MillsteinLocal.Areas.Admin.Models
{
    public class BaseModel
    {
                public Contact ContantInfo = ManageContact.GetSingleContact();

        public string Truncate(string text, int length = 200, string ellipsis = "...", bool keepFullWordAtEnd = true)
        {
            string txtWNoHTML = System.Text.RegularExpressions.Regex.Replace(text, @"<[^>]+>", "").Trim();

            if (String.IsNullOrEmpty(txtWNoHTML))
            {
                return string.Empty;
            }

            if (txtWNoHTML.Length < length)
            {
                return txtWNoHTML;
            }

            txtWNoHTML = txtWNoHTML.Substring(0, length);

            if (keepFullWordAtEnd)
            {
                txtWNoHTML = txtWNoHTML.Substring(0, txtWNoHTML.LastIndexOf(' '));
            }

            return txtWNoHTML + ellipsis;
        }
    }
    }

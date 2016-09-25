using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDeveloper.API.Models
{
    public class SelectItem
    {/*
        Value="0"
        Text = "No promotions.",
        Selected=false
        */
        public string Value { get; set; }
        public string Text { get; set; }
        public bool Selected { get; set; }
    }

}
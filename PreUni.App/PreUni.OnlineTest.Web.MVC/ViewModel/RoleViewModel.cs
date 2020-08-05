using PreUni.Core.EFModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PreUni.OnlineTest.Web.MVC.ViewModel
{
    public class RoleViewModel
    {
        public RoleViewModel()
        {
        }

        public RoleViewModel(ApplicationRole role)
        {
            Id = role.Id;
            Name = role.Name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
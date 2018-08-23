using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PanelWork.Models;

namespace PanelWork.ViewModel
{
    public class Mymodel
    {




        public List<Istifadeci> _istifadeciler { get; set; }
        public List<Mehsul> _mehsul { get; set; }
        public List<Rol> _rollar { get; set; }

        public IEnumerable<Sifari> _sifarisssler { get; set; }



        public List<Sifari> _sifarisler { get; set; }
        public List<SifarisNovu> _sifarisnovleri { get; set; }


    }
}
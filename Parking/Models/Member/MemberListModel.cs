using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parking.Models.Member
{
    public class MemberListModel
    {
      
        public string CardType { get; set; }

        public List<CardType> cardTypeList { get; set; }

        public List<MemberModel> memberlist { get; set; }
    }
}
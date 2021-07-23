using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP_MVC_CV_Prj.Models.Entity;

namespace ASP_MVC_CV_Prj.Models.Skill
{
    public class ToolAndSkill
    {
        public IEnumerable<Abilities> MAbilities { get; set; }
        public IEnumerable<Tools>  MTools { get; set; }
    }
}
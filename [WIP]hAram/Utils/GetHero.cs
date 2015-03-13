using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using LeagueSharp.Common;

namespace hAram.Utils
{
    class GetHero
    {
        Obj_AI_Hero Player = ObjectHandler.Player;

        public Obj_AI_Hero LessHealthHero(float range)
        {
            //return Player;
            return ObjectHandler.Get<Obj_AI_Hero>().Allies
                        .Where(hero => Player.Distance(hero) <= range)
                        .OrderBy(h => h.HealthPercentage()).ToList()[0];
        }

        public List<Obj_AI_Hero> GetAlliesList()
        {
            return ObjectHandler.Get<Obj_AI_Hero>().Allies;
        }
    }
}

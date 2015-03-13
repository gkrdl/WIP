using LeagueSharp;
using LeagueSharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hAram.Champions
{
    class nami : Base
    {
        public nami()
        {
            Game.PrintChat("hAram : " + Player.ChampionName + "Loaded.");
        }

        public override void Game_OnUpdate(EventArgs args)
        {
            base.Game_OnUpdate(args);

            var lowHealthHero = ObjectHandler.Get<Obj_AI_Hero>().Allies
                        .FindAll(hero => Player.Distance(hero) <= W.Range)
                        .OrderBy(h => h.HealthPercentage()).ToList()[0];

            if (lowHealthHero != null)
            {
                if (lowHealthHero.HealthPercentage() <= 70)
                {
                    W.CastOnUnit(lowHealthHero);
                }
            }
            
            CastSpell(Q, qData);
            CastSpell(W, wData);
            CastSpell(E, eData);

            target = GetTarget(R);
            if (R.IsKillable(target) || R.CastIfWillHit(target, 2))
            {
                CastSpell(R, rData);
            }
        }
    }
}

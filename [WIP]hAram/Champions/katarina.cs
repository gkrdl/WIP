using LeagueSharp;
using LeagueSharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hAram.Champions
{
    class katarina : Base
    {
        public katarina()
        {
            Game.PrintChat("hAram : " + Player.ChampionName + "Loaded.");
        }

        public override void Game_OnUpdate(EventArgs args)
        {
            base.Game_OnUpdate(args);

            if (Killable(true, true, true, false))
                CastSpell(E, eData);
            
            CastSpell(Q, qData);
            CastSpell(W, wData);

            //Killable()
            target = GetTarget(R);
            if (R.IsKillable(target))
                ;
        }

        public override void AntiGapcloser_OnEnemyGapcloser(ActiveGapcloser gapcloser)
        {
            if (gapcloser.Sender.IsEnemy)
            {
                if (Player.Distance(gapcloser.End) <= 200)
                {
                    var moreDistanceHero = GetObject.MoreDistanceHero(E.Range);

                    E.CastOnUnit(moreDistanceHero);
                }
            }
            
        }
    }
}

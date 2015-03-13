using LeagueSharp;
using LeagueSharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hAram.Champions
{
    class nunu : Base
    {
        public nunu()
        {
            Game.PrintChat("hAram : " + Player.ChampionName + "Loaded.");
        }

        public override void Game_OnUpdate(EventArgs args)
        {
            base.Game_OnUpdate(args);

            var moreRangeHero = ObjectHandler.Get<Obj_AI_Hero>().Allies
.FindAll(hero => Player.Distance(hero) <= W.Range)
.OrderBy(h => Orbwalking.GetRealAutoAttackRange(h)).ToList()[0];

            if (moreRangeHero != null)
                W.CastOnUnit(moreRangeHero);
            else
                W.CastOnUnit(Player);

            CastSpell(E, eData);

            var minion = MinionManager.GetMinions(Player.Position, Q.Range)
                                    .OrderBy(m => Player.Distance(m)).ToList()[0];

            if (minion != null && Player.HealthPercentage() <= 80)
                Q.CastOnUnit(minion);

            target = GetTarget(R);
            if (R.IsKillable(target) || R.CastIfWillHit(target, 3) || (status == "Fight" && Player.HealthPercentage() <= 30))
                CastSpell(R, rData);
        }

        public override void AntiGapcloser_OnEnemyGapcloser(ActiveGapcloser gapcloser)
        {
            if (gapcloser.Sender.IsEnemy)
            {
                if (Player.Distance(gapcloser.End) <= 200)
                    AntiGapClose(E);
            }
            
        }
    }
}

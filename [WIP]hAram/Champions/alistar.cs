using LeagueSharp;
using LeagueSharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hAram.Champions
{
    class alistar : Base
    {
        public alistar()
        {
            Game.PrintChat("hAram : " + Player.ChampionName + "Loaded.");
        }

        public override void Game_OnUpdate(EventArgs args)
        {
            base.Game_OnUpdate(args);

            var lowHealthHero = ObjectHandler.Get<Obj_AI_Hero>().Allies
                        .FindAll(hero => Player.Distance(hero) <= E.Range)
                        .OrderBy(h => h.HealthPercentage()).ToList()[0];

            if (lowHealthHero.HealthPercentage() <= 60)
                CastSpell(E, eData);

            CastSpell(W, wData);
            CastSpell(Q, qData);

            if (status == "Fight" && Player.HealthPercentage() <= 50)
                CastSpell(R, rData);
        }
    }
}

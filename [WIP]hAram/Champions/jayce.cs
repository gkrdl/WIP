using LeagueSharp;
using LeagueSharp.Common;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hAram.Champions
{
    class jayce : Base
    {
        Spell hammerQ = new Spell(SpellSlot.Q, 600);
        Spell hammerW = new Spell(SpellSlot.W, 285);
        Spell hammerE = new Spell(SpellSlot.E, 230);

        public jayce()
        {
            Game.PrintChat("hAram : " + Player.ChampionName + "Loaded.");
            hammerQ.SetTargetted(0.15f, float.MaxValue);
            hammerE.SetTargetted(0.15f, float.MaxValue);
        }

        public override void Game_OnUpdate(EventArgs args)
        {
            base.Game_OnUpdate(args);

            
            CastSpell(Q, qData);
            CastSpell(W, wData);

            if (Q.Instance.Name.Equals("jayceshockblast"))
            {
                CastSpell(Q, qData);
                CastSpell(W, wData);
                CastSpell(E, eData);

                if (!Q.IsReady() && !W.IsReady() && !E.IsReady())
                    R.Cast();
            }
            else
            {
                CastSpell(hammerQ, hammerQ.Instance);
                CastSpell(hammerW, hammerW.Instance);
                CastSpell(hammerE, hammerE.Instance);

                R.Cast();
            }
        }

        public override void Obj_AI_Hero_OnProcessSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (sender.IsMe && args.SData.Name.Equals("jayceshockblast"))
            {

                Vector3 ePosition = Player.ServerPosition + Vector3.Normalize(args.End - Player.ServerPosition) * 50;
                if (E.IsReady())
                    E.Cast(ePosition);
            }
        }
        
    }
}

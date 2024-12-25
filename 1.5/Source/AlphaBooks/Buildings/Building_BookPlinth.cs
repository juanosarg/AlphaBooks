using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;


namespace AlphaBooks
{
    public class Building_BookPlinth: Building_RuinedBookcase
    {

        public override void DrawAt(Vector3 drawLoc, bool flip = false)
        {
           
            drawLoc -= Altitudes.AltIncVect * 2f;

            if (def.drawerType == DrawerType.RealtimeOnly || !Spawned)
            {
                Graphic.Draw(drawLoc, flip ? Rotation.Opposite : Rotation, this);
            }
            SilhouetteUtility.DrawGraphicSilhouette(this, drawLoc);
            Comps_PostDraw();

            Rot4 rot = base.Rotation.Rotated(RotationDirection.Counterclockwise);
            float num = (base.Rotation == Rot4.North || base.Rotation == Rot4.South) ? 0.155f : 0.16f;
            Vector3 a = rot.FacingCell.ToVector3() * num;
            Vector3 b = rot.FacingCell.ToVector3() * ((float)(-MaximumBooks) * num * 0.5f);
            Vector3 b2 = RotOffsets[base.Rotation.AsInt];
            for (int i = 0; i < HeldBooks.Count; i++)
            {
                Book book = HeldBooks[i];
               
                Vector3 loc = drawLoc + b + b2 + DrawOffset + a * i;

                Graphic graphic = book.OpenGraphic.GetCopy(new Vector2(1.3f,1.3f), null);
                graphic?.DrawFromDef(loc, Rot4.North, null);

             
            }
            
        }

    }
}

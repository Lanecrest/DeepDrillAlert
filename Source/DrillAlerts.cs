using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace DeepDrillAlert
{
    public class DeepDrillAlert : Alert
    {
        // Check for forbidden deep drills
        public override AlertReport GetReport()
        {
            // Check for deep drills
            var deepDrills = Find.CurrentMap.listerBuildings.AllBuildingsColonistOfDef(ThingDefOf.DeepDrill);

            // Check if any are forbidden
            bool anyForbidden = deepDrills.Any(drill => drill.IsForbidden(Faction.OfPlayer));

            // Alert Notification
            return AlertReport.CulpritIs(anyForbidden ? deepDrills.First(drill => drill.IsForbidden(Faction.OfPlayer)) : null);
        }

        // Label text for the alert, supporting translations
        public DeepDrillAlert()
        {
            this.defaultLabel = "DeepDrillAlert_Label".Translate();
            this.defaultExplanation = "DeepDrillAlert_Explanation".Translate();
        }
    }
}
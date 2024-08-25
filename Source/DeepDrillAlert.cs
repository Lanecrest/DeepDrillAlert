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
        // Method to check for forbidden deep drills
        public override AlertReport GetReport()
        {
            // Find all deep drills on the map
            var deepDrills = Find.CurrentMap.listerBuildings.AllBuildingsColonistOfDef(ThingDefOf.DeepDrill);

            // Check if any deep drills forbidden
            bool anyForbidden = deepDrills.Any(drill => drill.IsForbidden(Faction.OfPlayer));

            // Place an alert if there are forbidden deep drills
            return AlertReport.CulpritIs(anyForbidden ? deepDrills.First(drill => drill.IsForbidden(Faction.OfPlayer)) : null);
        }

        // Label and Explanation parameters, text is defined through XML files to support translations
        public DeepDrillAlert()
        {
            this.defaultLabel = "DeepDrillAlert_Label".Translate();
            this.defaultExplanation = "DeepDrillAlert_Explanation".Translate();
        }
    }
}
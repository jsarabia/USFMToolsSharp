using System;
using System.Collections.Generic;
using System.Text;
using USFMToolsSharp.Models;
using USFMToolsSharp.Models.Markers;

namespace USFMToolsSharp.LinterModules
{
    public class MissingXOMarkerProps : ILinterModule
    {
        public List<LinterResult> Lint(USFMDocument input)
        {
            List<LinterResult> results = new List<LinterResult>();
            foreach(Marker marker in input.GetChildMarkers<XOMarker>())
            {
                if (String.IsNullOrEmpty(((XOMarker)marker).OriginRef))
                {
                    results.Add(new LinterResult
                    {
                        Position = marker.Position,
                        Level = LinterLevel.Error,
                        Message = "Cross Reference Origin Reference is missing"
                    });
                }
            }
            return results;
        }
        
    }
}
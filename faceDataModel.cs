using System;
using System.Collections.Generic;
using System.Linq;
using HelixToolkit.Wpf.SharpDX;
using SharpDX;

namespace ACMApp
{
    public class faceDataModel : baseDataModel
    {
        /// <summary>
        /// Unique ID of the direct shape face object the panel came from.
        /// </summary>
        public string hostFaceId { get; private set; }
        public IList<edgeDataModel> edges { get; private set; }
        public DiffuseMaterial faceMaterialTest { get; private set; }

        public faceDataModel(IEnumerable<Vector3> facePts, IEnumerable<int> faceIndices, string faceHostId, IList<IEnumerable<Vector3>> edgePts)
        {
            geoType = geoDataType.FACE;
            faceMaterialTest = new DiffuseMaterial() {DiffuseColor = new Color4(28, 62, 149, 100) };

            edges = createEdgeDataModels(edgePts);

            // create mesh
            MeshBuilder mb = new MeshBuilder(false, false, false);
            mb.Positions.AddRange(facePts);
            mb.TriangleIndices.AddRange(faceIndices);

            geometry = mb.ToMeshGeometry3D();
            
            //material = new DiffuseMaterial() { DiffuseColor = new Color4(28, 62, 149, 255) };

            hostFaceId = faceHostId;
        }

        /// <summary>
        /// Create the returnLegDataModels for the panel.
        /// </summary>
        /// <param name="edgeEndPts"></param>
        /// <param name="edgeShapes"></param>
        /// <returns></returns>
        private IList<edgeDataModel> createEdgeDataModels(IEnumerable<IEnumerable<Vector3>> edgeEndPts)
        {
            IList<edgeDataModel> edges = new List<edgeDataModel>();

            foreach (IEnumerable<Vector3> endPts in edgeEndPts)
            {
                edgeDataModel edm = new edgeDataModel(endPts);
                edges.Add(edm);
            }

            return edges;
        }


    }
}
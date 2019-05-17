using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GratingsApp
{
    class Functions
    {
        public void CentreMesh(ref double Length, ref double Mesh, ref double MeshExtreme, ref int Quantity)
        {
            double x = ((Length / 2) / Mesh - Math.Floor((Length / 2) / Mesh)) * Mesh;
            MeshExtreme = Math.Round(x, 3);
            Quantity = 2 * Convert.ToInt32((Length / 2 - MeshExtreme) / Mesh + 1) - 1;
        }

        public void EvenEye(ref double Length, ref double Thickness, ref double NominalMesh, ref double FinishMesh, ref int Quantity)
        {
            double CalcLength = Length - Thickness;
            double[] quantity = new double[3];

            quantity[0] = Math.Round(CalcLength / NominalMesh);
            quantity[1] = quantity[0] + 1;
            quantity[2] = quantity[0] - 1;

            double[] Mesh = new double[3];
            for (int i = 0; i < 3; i++)
            {
                Mesh[i] = Math.Round((CalcLength / quantity[i]), 2);
            }

            double[] diff = new double[3];
            for (int i = 0; i <= 2; i++)
            {
                diff[i] = Math.Round(Math.Abs((Mesh[i] - NominalMesh)), 2);
            }

            double mindiff = diff[0];
            FinishMesh = Mesh[0];
            Quantity = Convert.ToInt32(quantity[0]) - 1;

            for (int i = 0; i <= 2; i++)
            {
                if (mindiff > diff[i])
                {
                    mindiff = diff[i];
                    FinishMesh = Mesh[i];
                    Quantity = Convert.ToInt32(quantity[i]) - 1;
                }
            }
        }
        public void FromFullMesh(ref double Length, ref double Thickness, ref double Mesh, ref double FinishMesh, ref int Quantity)
        {
            double x = ((Length - Thickness / 2) / Mesh - Math.Floor((Length - Thickness / 2) / Mesh)) * Mesh;
            FinishMesh = Math.Round(x, 3);
            Quantity = Convert.ToInt32(((Length - Thickness / 2) - FinishMesh) / Mesh);
        }


        public void Correction(ref double Correction, ref double thickness, ref double Mesh1, ref double Mesh, ref double Mesh2)
        {
            if (Correction < Mesh1)
            {
                Mesh1 = Mesh1 - Correction;

            }
            else if (Correction > Mesh1)
            {
                Mesh1 = Mesh1 - Correction + Mesh;

            }
            Mesh1 = Math.Round(Mesh1, 3);
            Mesh2 = Mesh2 + Correction;

            if (Mesh2 > (Mesh + thickness / 2))
            { Mesh2 = Mesh2 - Mesh; }
            Mesh2 = Math.Round(Mesh2, 3);
        }
    }
}

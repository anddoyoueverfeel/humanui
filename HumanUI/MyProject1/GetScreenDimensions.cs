﻿using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using Grasshopper.Kernel;
using Rhino.Geometry;
using Rhino;

namespace HumanUI
{
    public class GetScreenDimensions : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the GetScreenDimensions class.
        /// </summary>
        public GetScreenDimensions()
            : base("Get Screen Dimensions", "GetScreen",
                "Gets the dimensions of the current screen",
                "Human", "UI Main")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("Width", "W", "Width", GH_ParamAccess.item);
            pManager.AddNumberParameter("Height", "H", "Height", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Screen sc = Screen.FromHandle(RhinoApp.MainApplicationWindow.Handle);

            Control c = new Control();
            Graphics graphics = c.CreateGraphics();
            double mult = graphics.DpiX / 96;
            double A = sc.Bounds.Right / mult;
            double B = sc.Bounds.Bottom / mult;
            DA.SetData("Height", B);
            DA.SetData("Width", A);
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return Properties.Resources.screenDimensions;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("{415bcdd1-11f0-4eae-ba0b-c48b50037de3}"); }
        }
    }
}
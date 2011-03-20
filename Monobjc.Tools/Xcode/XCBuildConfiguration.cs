﻿//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2011 - Laurent Etiemble
//
// Monobjc is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// any later version.
//
// Monobjc is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with Monobjc.  If not, see <http://www.gnu.org/licenses/>.
//
using System;
using System.Collections.Generic;
using System.IO;

namespace Monobjc.Tools.Xcode
{
    public class XCBuildConfiguration : PBXElement
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref = "XCBuildConfiguration" /> class.
        /// </summary>
        public XCBuildConfiguration()
        {
            this.Settings = new Dictionary<String, Object>();
        }

        /// <summary>
        ///   Gets or sets the base configuration reference.
        /// </summary>
        /// <value>The base configuration reference.</value>
        public PBXFileReference BaseConfigurationReference { get; set; }

        /// <summary>
        ///   Gets or sets the settings.
        /// </summary>
        /// <value>The settings.</value>
        public IDictionary<String, Object> Settings { get; set; }

        /// <summary>
        ///   Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public String Name { get; set; }

        /// <summary>
        ///   Gets the elemnt's nature.
        /// </summary>
        /// <value>The nature.</value>
        public override PBXElementType Nature
        {
            get { return PBXElementType.XCBuildConfiguration; }
        }

        /// <summary>
        ///   Gets the description.
        /// </summary>
        /// <value>The description.</value>
        public override string Description
        {
            get { return "BuildConfiguration"; }
        }

        /// <summary>
        ///   Accepts the specified visitor.
        /// </summary>
        /// <param name = "visitor">The visitor.</param>
        public override void Accept(IPBXVisitor visitor)
        {
            visitor.Visit(this);

            if (this.BaseConfigurationReference != null)
            {
                this.BaseConfigurationReference.Accept(visitor);
            }
        }

        /// <summary>
        ///   Writes this element to the writer.
        /// </summary>
        /// <param name = "writer">The writer.</param>
        /// <param name = "map">The map.</param>
        public override void WriteTo(TextWriter writer, IDictionary<IPBXElement, string> map)
        {
            writer.writeElementPrologue(map, this);
            if (this.BaseConfigurationReference != null)
            {
                writer.WriteReference(map, "baseConfigurationReference", this.BaseConfigurationReference);
            }
            writer.WriteMap("settings", this.Settings);
            writer.WriteAttribute("name", this.Name);
            writer.writeElementEpilogue();
        }
    }
}
//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2013 - Laurent Etiemble
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
using System.IO;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using Monobjc.MSBuild.Utilities;
using Monobjc.Tools.Generators;

namespace Monobjc.MSBuild.Tasks
{
	public class EncryptArtwork : Task
	{
		/// <summary>
		/// Gets or sets a value indicating whether to do artwork combination.
		/// </summary>
		/// <value><c>true</c> to do artwork combination; otherwise, <c>false</c>.</value>
		public bool DoEncrypt { get; set; }

		/// <summary>
		/// Gets or sets the dir.
		/// </summary>
		/// <value>The dir.</value>
		[Required]
		public ITaskItem Directory { get; set; }

		/// <summary>
		/// Gets or sets the encryption seed.
		/// </summary>
		/// <value>The seed from which to derive the key.</value>
		[Required]
		public String EncryptionSeed { get; set; }

		public override bool Execute ()
		{
			// TODO: I18N
			this.Log.LogMessage ("Encrypting artwork...");

			ArtworkEncrypter combiner = new ArtworkEncrypter ();
			combiner.Logger = new ExecutionLogger (this);
			combiner.Encrypt (this.Directory.ToString (), this.EncryptionSeed);

			return true;
		}
	}
}

﻿using OfficeDevPnP.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeDevPnP.Core.Framework.Provisioning.Model.Drive
{
    /// <summary>
    /// Defines a Drive object
    /// </summary>
    public class DriveRoot : BaseModel, IEquatable<DriveRoot>
    {
        #region Public members

        /// <summary>
        /// The DriveUrl of the target DriveRoot
        /// </summary>
        public String DriveUrl { get; set; }

        /// <summary>
        /// Defines a collection of DriveItem items
        /// </summary>
        public DriveItemCollection DriveItems { get; private set; }

        #endregion

        #region Constructors

        public DriveRoot() : base()
        {
            this.DriveItems = new DriveItemCollection(this.ParentTemplate);
        }

        #endregion

        #region Comparison code

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Returns HashCode</returns>
        public override int GetHashCode()
        {
            return (String.Format("{0}|{1}|",
                DriveUrl.GetHashCode(),
                DriveItems.Aggregate(0, (acc, next) => acc += (next != null ? next.GetHashCode() : 0))
            ).GetHashCode());
        }

        /// <summary>
        /// Compares object with DriveRoot class
        /// </summary>
        /// <param name="obj">Object that represents DriveRoot</param>
        /// <returns>Checks whether object is User class</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is DriveRoot))
            {
                return (false);
            }
            return (Equals((DriveRoot)obj));
        }

        /// <summary>
        /// Compares DriveRoot object based on DriveUrl, and DriveItems
        /// </summary>
        /// <param name="other">User DriveRoot object</param>
        /// <returns>true if the DriveRoot object is equal to the current object; otherwise, false.</returns>
        public bool Equals(DriveRoot other)
        {
            if (other == null)
            {
                return (false);
            }

            return (this.DriveUrl == other.DriveUrl &&
                this.DriveItems.DeepEquals(other.DriveItems)
                );
        }

        #endregion
    }
}
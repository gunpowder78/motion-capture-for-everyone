﻿/*
Part of Bewegungsfelder 
(C) 2016 Ivo Herzig

[[LICENSE]]
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace Mocap.Core
{
    public class SensorBoneMap
    {
        private Dictionary<Bone, SensorBoneLink> links = new Dictionary<Bone, SensorBoneLink>();

        public IEnumerable<SensorBoneLink> Links { get { return links.Values; } }

        public event Action<SensorBoneLink> LinkAdded;

        public event Action<SensorBoneLink> LinkRemoved;

        public SensorBoneLink CreateLink(Bone bone, Sensor sensor)
        {
            if (links.ContainsKey(bone))
            {
                var removedLink = links[bone];
                links.Remove(bone);
                LinkRemoved?.Invoke(removedLink);
            }

            var link = new SensorBoneLink(bone, sensor);
            links.Add(bone, link);
            LinkAdded?.Invoke(link);

            return link;
        }

        public void RemoveLink(Bone bone)
        {
            if (links.ContainsKey(bone))
            {
                var link = links[bone];
                links.Remove(bone);
                LinkRemoved?.Invoke(link);
            }
        }

        public Dictionary<Bone, Quaternion> GetCalibratedSensorOrientations()
        {
            var result = new Dictionary<Bone, Quaternion>();
            foreach (var link in links.Values)
            {
                result.Add(link.Bone, link.GetCalibratedOrientation());
            }

            return result;
        }

        /// <summary>
        /// clear all links
        /// </summary>
        public void Clear()
        {
            links.Clear();
        }
    }

}

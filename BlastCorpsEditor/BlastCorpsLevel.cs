﻿using System;
using System.Collections.Generic;

namespace BlastCorpsEditor
{
   public class LevelHeader
   {
      public UInt16[] u16s = new UInt16[12];
      public Int32 gravity;
      public Int32 u1C; // TODO: identify
      public UInt32[] offsets = new UInt32[42];
   }

   public class BlastCorpsItem
   {
      public Int16 x { get; set; }
      public Int16 y { get; set; }
      public Int16 z { get; set; }
   }

   public class AmmoBox : BlastCorpsItem
   {
      public UInt16 type;

      public AmmoBox(Int16 x, Int16 y, Int16 z, UInt16 type)
      {
         this.x = x;
         this.y = y;
         this.z = z;
         this.type = type;
      }

      public override string ToString()
      {
         return x + ", " + y + ", " + z + ", " + type;
      }
   }

   public class Collision24
   {
      public Int16 x1, y1, z1;
      public Int16 x2, y2, z2;
      public Int16 x3, y3, z3;
      public UInt16 type;

      public Collision24(Int16 x1, Int16 y1, Int16 z1, Int16 x2, Int16 y2, Int16 z2, Int16 x3, Int16 y3, Int16 z3, UInt16 t)
      {
         this.x1 = x1;
         this.y1 = y1;
         this.z1 = z1;
         this.x2 = x2;
         this.y2 = y2;
         this.z2 = z2;
         this.x3 = x3;
         this.y3 = y3;
         this.z3 = z3;
         this.type = t;
      }

      public override string ToString()
      {
         return "(" + x1 + "," + y1 + "," + z1 + ") (" + x2 + "," + y2 + "," + z2 + ") (" + x3 + "," + y3 + "," + z3 + ")";
      }
   }

   public class CommPoint : BlastCorpsItem
   {
      public UInt16 h6;

      public CommPoint(Int16 x, Int16 y, Int16 z, UInt16 h6)
      {
         this.x = x;
         this.y = y;
         this.z = z;
         this.h6 = h6;
      }

      public override string ToString()
      {
         return x + ", " + y + ", " + z + ", " + h6;
      }
   }

   public class Object2C
   {
      // TODO: details on data members
      public UInt32 w0;
      public byte b5, b6, b7, b8, b9, bA, bB;
      public UInt32[] words;

      public Object2C(UInt32 w0, byte b5, byte b6, byte b7, byte b8, byte b9, byte bA, byte bB, UInt32[] words)
      {
         this.w0 = w0;
         this.b5 = b5;
         this.b6 = b6;
         this.b7 = b7;
         this.b8 = b8;
         this.b9 = b9;
         this.bA = bA;
         this.bB = bB;
         this.words = words;
      }
   }

   public class TerrainTri
   {
      public Int16 x1, y1, z1;
      public Int16 x2, y2, z2;
      public Int16 x3, y3, z3;
      public byte b12, b13;

      public TerrainTri(Int16 x1, Int16 y1, Int16 z1, Int16 x2, Int16 y2, Int16 z2, Int16 x3, Int16 y3, Int16 z3, byte b12, byte b13)
      {
         this.x1 = x1;
         this.y1 = y1;
         this.z1 = z1;
         this.x2 = x2;
         this.y2 = y2;
         this.z2 = z2;
         this.x3 = x3;
         this.y3 = y3;
         this.z3 = z3;
         this.b12 = b12;
         this.b13 = b13;
      }

      public override string ToString()
      {
         return "(" + x1 + "," + y1 + "," + z1 + ") (" + x2 + "," + y2 + "," + z2 + ") (" + x3 + "," + y3 + "," + z3 + ") " + b12 + ":" + b13;
      }
   }

   public class TerrainGroup
   {
      public List<TerrainTri> triangles = new List<TerrainTri>();
   }

   public class LevelBounds
   {
      public Int16 x1, z1, x2, z2;

      public override string ToString()
      {
         return x1 + ", " + z1 + " " + x2 + ", " + z2;
      }
   }

   public class RDU : BlastCorpsItem
   {
      public RDU(Int16 x, Int16 y, Int16 z)
      {
         this.x = x;
         this.y = y;
         this.z = z;
      }

      public override string ToString()
      {
         return x + ", " + y + ", " + z;
      }
   }

   public class TNTCrate : BlastCorpsItem
   {
      public byte b6; // TODO
      public byte timer;
      public Int16 h8, hA; // TODO

      public TNTCrate(Int16 x, Int16 y, Int16 z, byte b6, byte timer, Int16 h8, Int16 hA)
      {
         this.x = x;
         this.y = y;
         this.z = z;
         this.b6 = b6;
         this.timer = timer;
         this.h8 = h8;
         this.hA = hA;
      }

      public override string ToString()
      {
         return x + ", " + y + ", " + z + ", " + b6.ToString("X2") + ", " + timer.ToString("X2") + ", " + h8.ToString("X4") + ", " + hA.ToString("X4");
      }
   }

   public class SquareBlock : BlastCorpsItem
   {
      public byte type;
      public byte hole;
      public UInt16 extra;
      public class Node
      {
         public Int16[] x;
         public Int16[] y;
         public Int16[] z;
         public byte[] other = new byte[4];
      }
      public List<Node> nodes = new List<Node>();

      public SquareBlock(Int16 x, Int16 y, Int16 z, byte type, byte hole)
      {
         this.x = x;
         this.y = y;
         this.z = z;
         this.type = type;
         this.hole = hole;
      }

      public void addNode(Int16 x1, Int16 y1, Int16 z1, Int16 x2, Int16 y2, Int16 z2, Int16 x3, Int16 y3, Int16 z3, byte[] data, int index)
      {
         Node n = new Node();
         n.x = new Int16[] { x1, x2, x3 };
         n.y = new Int16[] { y1, y2, y3 };
         n.z = new Int16[] { z1, z2, z3 };
         Array.Copy(data, index, n.other, 0, 4);
         nodes.Add(n);
      }

      public override string ToString()
      {
         return x + ", " + y + ", " + z + ", " + type + ", " + hole + ((hole == 8) ? (", " + extra) : "");
      }
   }

   public class Bounds
   {
      public Int16 x1, z1, x2, z2;
      public UInt16 todo;

      public Bounds(Int16 x1, Int16 z1, Int16 x2, Int16 z2, UInt16 todo)
      {
         this.x1 = x1;
         this.z1 = z1;
         this.x2 = x2;
         this.z2 = z2;
         this.todo = todo;
      }

      public override string ToString()
      {
         return x1 + ", " + z1 + ", " + x2 + ", " + z2 + ", " + todo;
      }
   }

   public class Vehicle : BlastCorpsItem
   {
      public byte type;
      public Int16 heading;

      public Vehicle(byte type, Int16 x, Int16 y, Int16 z, Int16 heading)
      {
         this.type = type;
         this.x = x;
         this.y = y;
         this.z = z;
         this.heading = heading;
      }

      public override string ToString()
      {
         return type.ToString("X2") + ": " + x + ", " + y + ", " + z + ", " + heading;
      }
   }

   public class Carrier : BlastCorpsItem
   {
      public byte speed {get; set;}
      public UInt16 heading {get; set;}
      public UInt16 distance { get; set; }

      public override string ToString()
      {
         return speed + ", " + x + ", " + y + ", " + z + ", " + heading;
      }
   }

   public class Building : BlastCorpsItem
   {
      public UInt16 type;
      // TODO: what are these?
      public byte counter;
      public byte b9;
      public UInt16 behavior;
      public UInt16 speed;

      public Building(Int16 x, Int16 y, Int16 z, UInt16 type, byte counter, byte b9, UInt16 behavior, UInt16 speed)
      {
         this.x = x;
         this.y = y;
         this.z = z;
         this.type = type;
         this.counter = counter;
         this.b9 = b9;
         this.behavior = behavior;
         this.speed = speed;
      }

      public override string ToString()
      {
         return x + ", " + y + ", " + z + ", " + type + ", " + counter + ", " + b9 + ", " + behavior + ", " + speed;
      }
   }

   public class TrainPlatform
   {
      public struct StoppingTriangle
      {
         public Int16 x1, x2, x3, z1, z2, z3;
      }
      public struct PlatformCollision
      {
         public Int16 x1, x2, x3, y1, y2, y3, z1, z2, z3;
         public UInt16 h12;
         public byte b14;
      }
      public byte b0;
      public byte b1;
      public StoppingTriangle[] stoppingZone;
      public UInt32 word;
      public PlatformCollision[] collision;
      public byte[] someList;
   }

   public class CollisionTri
   {
      public Int16 x1, y1, z1;
      public Int16 x2, y2, z2;
      public Int16 x3, y3, z3;
      public UInt16 h12;
      public byte b14, b15;

      public CollisionTri(Int16 x1, Int16 y1, Int16 z1, Int16 x2, Int16 y2, Int16 z2, Int16 x3, Int16 y3, Int16 z3, UInt16 h12, byte b14, byte b15)
      {
         this.x1 = x1;
         this.y1 = y1;
         this.z1 = z1;
         this.x2 = x2;
         this.y2 = y2;
         this.z2 = z2;
         this.x3 = x3;
         this.y3 = y3;
         this.z3 = z3;
         this.h12 = h12;
         this.b14 = b14;
         this.b15 = b15;
      }

      public override string ToString()
      {
         return "(" + x1 + "," + y1 + "," + z1 + ") (" + x2 + "," + y2 + "," + z2 + ") (" + x3 + "," + y3 + "," + z3 + ") " + h12 + ":" + b14 + ":" + b15;
      }
   }

   public class CollisionGroup
   {
      public List<CollisionTri> triangles = new List<CollisionTri>();
   }

   public class BlastCorpsLevel
   {
      public LevelHeader header = new LevelHeader();
      public List<AmmoBox> ammoBoxes = new List<AmmoBox>();
      public List<Collision24> collisions = new List<Collision24>();
      public List<CommPoint> commPoints = new List<CommPoint>();
      public List<Object2C> object2Cs = new List<Object2C>();
      public List<TerrainGroup> terrainGroups = new List<TerrainGroup>();
      public List<RDU> rdus = new List<RDU>();
      public List<TNTCrate> tntCrates = new List<TNTCrate>();
      public List<SquareBlock> squareBlocks = new List<SquareBlock>();
      public List<Bounds> bounds40 = new List<Bounds>();
      public List<Bounds> bounds44 = new List<Bounds>();
      public LevelBounds bounds = new LevelBounds();
      public List<Vehicle> vehicles = new List<Vehicle>();
      public Carrier carrier = new Carrier();
      public List<Building> buildings = new List<Building>();
      private byte[] copy48;
      private byte[] copy58;
      private byte[] copy60;
      private byte[] copy64;
      public List<TrainPlatform> trainPlatforms = new List<TrainPlatform>();
      public List<CollisionGroup> collisionGroups = new List<CollisionGroup>();
      private byte[] copy70;
      private byte[] copy74;
      private byte[] vertData;
      public byte[] copyLevelData;
      public byte[] displayList;

      // 0x00-0x20: Header
      private void decodeHeader(byte[] data)
      {
         // read in 12 u16s
         for (uint i = 0; i < header.u16s.Length; i++)
         {
            header.u16s[i] = BE.U16(data, i*2);
         }
         // read in two signed 32 values
         header.gravity = BE.I32(data, 0x18);
         header.u1C = BE.I32(data, 0x1C);
         // read in section offsets
         for (uint i = 0; i < header.offsets.Length; i++)
         {
            header.offsets[i] = BE.U32(data, 0x20 + i * 4);
         }
      }

      // 0x20: Ammo
      // [XX XX] [YY YY] [ZZ ZZ] [TT TT]
      private void decodeAmmoBoxes(byte[] data)
      {
         uint start = BE.U32(data, 0x20);
         uint end = BE.U32(data, 0x24);
         for (uint idx = start; idx < end; idx += 8)
         {
            Int16 x, y, z;
            UInt16 t;
            x = BE.I16(data, idx);
            y = BE.I16(data, idx + 2);
            z = BE.I16(data, idx + 4);
            t = BE.U16(data, idx + 6);
            AmmoBox ammo = new AmmoBox(x, y, z, t);
            ammoBoxes.Add(ammo);
         }
      }

      // 0x24: Collision triangles
      // [X1 X1] [Y1 Y1] [Z1 Z1] [X2 X2] [Y2 Y2] [Z2 Z2] [X3 X3] [Y3 Y3] [Z3 Z3] [?? ??]
      private void decodeCollision24(byte[] data)
      {
         uint start = BE.U32(data, 0x24);
         uint end = BE.U32(data, 0x28);
         for (uint idx = start; idx < end; idx += 20)
         {
            Int16 x1, y1, z1;
            Int16 x2, y2, z2;
            Int16 x3, y3, z3;
            UInt16 t;
            x1 = BE.I16(data, idx);
            y1 = BE.I16(data, idx + 2);
            z1 = BE.I16(data, idx + 4);
            x2 = BE.I16(data, idx + 6);
            y2 = BE.I16(data, idx + 8);
            z2 = BE.I16(data, idx + 10);
            x3 = BE.I16(data, idx + 12);
            y3 = BE.I16(data, idx + 14);
            z3 = BE.I16(data, idx + 16);
            t = BE.U16(data, idx + 18);
            Collision24 zone = new Collision24(x1, y1, z1, x2, y2, z2, x3, y3, z3, t);
            collisions.Add(zone);
         }
      }

      // 0x28: Communication Point
      // [XX XX] [YY YY] [ZZ ZZ] [?? ??]
      private void decodeCommPoints(byte[] data)
      {
         uint start = BE.U32(data, 0x28);
         uint end = BE.U32(data, 0x2C);
         for (uint idx = start; idx < end; idx += 8)
         {
            Int16 x, y, z;
            UInt16 todo;
            x = BE.I16(data, idx);
            y = BE.I16(data, idx + 2);
            z = BE.I16(data, idx + 4);
            todo = BE.U16(data, idx + 6);
            CommPoint comm = new CommPoint(x, y, z, todo);
            commPoints.Add(comm);
         }
      }

      // 0x2C: TODO
      // {[W0 W0 W0 W0] [CC] [B5] [B6] [??] [??] [??] [??] [??] {[WC WC WC WC]}}
      private void decode2C(byte[] data)
      {
         uint start = BE.U32(data, 0x2C);
         uint end = BE.U32(data, 0x30);
         uint idx = start;
         while (idx < end)
         {
            UInt32 w0;
            byte count, b5, b6, b7, b8, b9, bA, bB;
            w0 = BE.U32(data, idx);
            count = data[idx+4];
            b5 = data[idx+5];
            b6 = data[idx+6];
            b7 = data[idx+7];
            b8 = data[idx+8];
            b9 = data[idx+9];
            bA = data[idx+0xA];
            bB = data[idx+0xB];
            UInt32[] words = new UInt32[count-1];
            idx += 0xC;
            for (int i = 0; i < count - 1; i++) {
               words[i] = BE.U32(data, idx);
               idx += 4;
            }
            Object2C obj = new Object2C(w0, b5, b6, b7, b8, b9, bA, bB, words);
            object2Cs.Add(obj);
         }
      }

      // 0x30: Terrain data
      // [EE EE EE EE] {[X1 X1] [Y1 Y1] [Z1 Z1] [X2 X2] [Y2 Y2] [Z2 Z2] [X3 X3] [Y3 Y3] [Z3 Z3] [AA] [BB]}
      private void decodeTerrain(byte[] data)
      {
         uint start = BE.U32(data, 0x30);
         uint end = BE.U32(data, 0x34);
         uint idx = start;
         uint next;
         while (idx < end)
         {
            next = start + BE.U32(data, idx);
            idx += 4;
            TerrainGroup tg = new TerrainGroup();
            while (idx < next)
            {
               Int16 x1, y1, z1, x2, y2, z2, x3, y3, z3;
               x1 = BE.I16(data, idx);
               y1 = BE.I16(data, idx + 2);
               z1 = BE.I16(data, idx + 4);
               x2 = BE.I16(data, idx + 6);
               y2 = BE.I16(data, idx + 8);
               z2 = BE.I16(data, idx + 0xA);
               x3 = BE.I16(data, idx + 0xC);
               y3 = BE.I16(data, idx + 0xE);
               z3 = BE.I16(data, idx + 0x10);
               tg.triangles.Add(new TerrainTri(x1, y1, z1, x2, y2, z2, x3, y3, z3, data[idx + 0x12], data[idx + 0x13]));
               idx += 0x14;
            }
            terrainGroups.Add(tg);
         }
      }

      // 0x34: RDUs
      // [XX XX] [YY YY] [ZZ ZZ]
      private void decodeRDUs(byte[] data)
      {
         uint start = BE.U32(data, 0x34);
         uint end = BE.U32(data, 0x38);
         for (uint idx = start; idx < end; idx += 6)
         {
            Int16 x, y, z;
            x = BE.I16(data, idx);
            y = BE.I16(data, idx + 2);
            z = BE.I16(data, idx + 4);
            RDU rdu = new RDU(x, y, z);
            rdus.Add(rdu);
         }
      }

      // 0x38: TNT crates
      // [XX XX] [YY YY] [ZZ ZZ] [B6] [TT] [H8 H8] [HA HA]
      private void decodeTNTCrates(byte[] data)
      {
         uint start = BE.U32(data, 0x38);
         uint end = BE.U32(data, 0x3C);
         for (uint idx = start; idx < end; idx += 12)
         {
            Int16 x, y, z, h8, hA;
            x = BE.I16(data, idx);
            y = BE.I16(data, idx + 2);
            z = BE.I16(data, idx + 4);
            h8 = BE.I16(data, idx + 8);
            hA = BE.I16(data, idx + 0xA);
            TNTCrate tnt = new TNTCrate(x, y, z, data[idx + 6], data[idx + 7], h8, hA);
            tntCrates.Add(tnt);
         }
      }

      // 0x3C: Square blocks and holes
      // [NN NN] {[XX XX] [YY YY] [ZZ ZZ] [T1] [T2] (HH HH) {[X1 X1] [Y1 Y1] [Z1 Z1]... [AA] [BB] [CC] [DD]}}
      private void decodeSquareBlocks(byte[] data)
      {
         uint start = BE.U32(data, 0x3C);
         uint end = BE.U32(data, 0x40);
         uint idx = start;
         while (end > idx)
         {
            UInt16 num = BE.U16(data, idx);
            // TODO: is this proper termination condition?
            if (num == 0)
            {
               break;
            }
            idx += 2;
            for (int g = 0; g < num; g++)
            {
               Int16 x, y, z;
               byte type, hole;
               x = BE.I16(data, idx);
               y = BE.I16(data, idx + 2);
               z = BE.I16(data, idx + 4);
               type = data[idx + 6];
               hole = data[idx + 7];
               SquareBlock block = new SquareBlock(x, y, z, type, hole);
               squareBlocks.Add(block);
               idx += 8;
               if (hole == 8)
               {
                  block.extra = BE.U16(data, idx);
                  idx += 2;
                  for (int i = 0; i < 8; i++)
                  {
                     Int16 x2, y2, z2, x3, y3, z3;
                     x = BE.I16(data, idx);
                     y = BE.I16(data, idx + 2);
                     z = BE.I16(data, idx + 4);
                     x2 = BE.I16(data, idx + 6);
                     y2 = BE.I16(data, idx + 8);
                     z2 = BE.I16(data, idx + 0xA);
                     x3 = BE.I16(data, idx + 0xC);
                     y3 = BE.I16(data, idx + 0xE);
                     z3 = BE.I16(data, idx + 0x10);
                     block.addNode(x, y, z, x2, y2, z2, x3, y3, z3, data, (int)(idx + 0x12));
                     idx += 22;
                  }
               }
            }
         }
      }

      // 0x40: TODO some bounding boxes
      // [X1 X1] [Z1 Z1] [X2 X2] [Z2 Z2] [?? ??]
      private void decodeBounds40(byte[] data)
      {
         uint start = BE.U32(data, 0x40);
         uint end = BE.U32(data, 0x44);
         for (uint idx = start; idx < end; idx += 10)
         {
            Int16 x1, z1, x2, z2;
            UInt16 todo;
            x1 = BE.I16(data, idx + 0);
            z1 = BE.I16(data, idx + 2);
            x2 = BE.I16(data, idx + 4);
            z2 = BE.I16(data, idx + 6);
            todo = BE.U16(data, idx + 8);
            Bounds bound = new Bounds(x1, z1, x2, z2, todo);
            bounds40.Add(bound);
         }
      }

      // 0x44: TODO some bounding boxes?
      // [X1 X1] [Z1 Z1] [X2 X2] [Z2 Z2] [?? ??]
      private void decodeBounds44(byte[] data)
      {
         uint start = BE.U32(data, 0x44);
         uint end = BE.U32(data, 0x48);
         for (uint idx = start; idx < end; idx += 10)
         {
            Int16 x1, z1, x2, z2;
            UInt16 todo;
            x1 = BE.I16(data, idx + 0);
            z1 = BE.I16(data, idx + 2);
            x2 = BE.I16(data, idx + 4);
            z2 = BE.I16(data, idx + 6);
            todo = BE.U16(data, idx + 8);
            Bounds bound = new Bounds(x1, z1, x2, z2, todo);
            bounds44.Add(bound);
         }
      }

      // 0x48: TODO
      private void decode48(byte[] data)
      {
         copy48 = ArraySlice(data, BE.U32(data, 0x48), BE.U32(data, 0x4C));
      }

      // 0x4C: Level bounds
      // [X1 X1] [Z1 Z1] [X2 X2] [Z2 Z2]
      private void decodeLevelBounds(byte[] data)
      {
         uint start = BE.U32(data, 0x4C);
         bounds.x1 = BE.I16(data, start);
         bounds.z1 = BE.I16(data, start + 2);
         bounds.x2 = BE.I16(data, start + 4);
         bounds.z2 = BE.I16(data, start + 6);
      }

      // 0x50: Vehicles
      // [TT] [XX XX] [YY YY] [ZZ ZZ] [HH HH]
      private void decodeVehicles(byte[] data)
      {
         uint start = BE.U32(data, 0x50);
         uint end = BE.U32(data, 0x54);
         for (uint idx = start; idx < end; idx += 9)
         {
            Int16 x, y, z, h;
            x = BE.I16(data, idx + 1);
            y = BE.I16(data, idx + 3);
            z = BE.I16(data, idx + 5);
            h = BE.I16(data, idx + 7);
            Vehicle vehicle = new Vehicle(data[idx], x, y, z, h);
            vehicles.Add(vehicle);
         }
      }

      // 0x54: Missile carrier settings
      // [SS] [XX XX] [ZZ ZZ] [HH HH] [DD DD] [??]
      private void decodeMissileCarrier(byte[] data)
      {
         uint start = BE.U32(data, 0x54);
         carrier.speed = data[start];
         carrier.x = BE.I16(data, start + 1);
         carrier.z = BE.I16(data, start + 3);
         carrier.heading = BE.U16(data, start + 5);
         carrier.distance = BE.U16(data, start + 7);
      }

      // 0x58 TODO
      private void decode58(byte[] data)
      {
         copy58 = ArraySlice(data, BE.U32(data, 0x58), BE.U32(data, 0x5C));
      }

      // 0x5C: Buildings
      // [XX XX] [YY YY] [ZZ ZZ] [TT TT] [B8] [B9] [HA HA] [HC HC]
      private void decodeBuildings(byte[] data)
      {
         uint start = BE.U32(data, 0x5C);
         uint end = BE.U32(data, 0x60);
         for (uint idx = start; idx < end; idx += 14)
         {
            Int16 x, y, z;
            UInt16 type, hA, hC;
            x = BE.I16(data, idx);
            y = BE.I16(data, idx + 2);
            z = BE.I16(data, idx + 4);
            type = BE.U16(data, idx + 6);
            hA = BE.U16(data, idx + 0xA);
            hC = BE.U16(data, idx + 0xC);
            Building b = new Building(x, y, z, type, data[idx+8], data[idx+9], hA, hC);
            buildings.Add(b);
         }
      }

      // 0x60 TODO
      private void decode60(byte[] data)
      {
         copy60 = ArraySlice(data, BE.U32(data, 0x60), BE.U32(data, 0x64));
      }

      // 0x64 TODO
      private void decode64(byte[] data)
      {
         copy64 = ArraySlice(data, BE.U32(data, 0x64), BE.U32(data, 0x68));
      }

      // 0x68: Train platform and stopping zone
      // [B0] [B1]
      // [B2] {[X1 X1] [Z1 Z1] [X2 X2] [Z2 Z2] [X3 X3] [Z3 Z3]}
      // [WW WW WW WW]
      // [AA] {[H0 H0] [H2 H2] [H4 H4] [H6 H6] [H8 H8] [HA HA] [HC HC] [HE HE] [HG HG] [HI HI] [BK]}
      // [CC] {[BZ]}
      private void decodeTrainPlatform(byte[] data)
      {
         uint start = BE.U32(data, 0x68);
         uint end = BE.U32(data, 0x6C);
         uint idx = start;
         int count;
         while (idx < end)
         {
            TrainPlatform platform = new TrainPlatform();
            platform.b0 = data[idx++];
            platform.b1 = data[idx++];
            count = data[idx++];
            platform.stoppingZone = new TrainPlatform.StoppingTriangle[count];
            for (uint i = 0; i < count; i++)
            {
               TrainPlatform.StoppingTriangle triangle = new TrainPlatform.StoppingTriangle();
               triangle.x1 = BE.I16(data, idx);
               triangle.z1 = BE.I16(data, idx + 2);
               triangle.x2 = BE.I16(data, idx + 4);
               triangle.z2 = BE.I16(data, idx + 6);
               triangle.x3 = BE.I16(data, idx + 8);
               triangle.z3 = BE.I16(data, idx + 0xA);
               idx += 0xC;
               platform.stoppingZone[i] = triangle;
            }
            platform.word = BE.U32(data, idx);
            idx += 4;
            count = data[idx++];
            platform.collision = new TrainPlatform.PlatformCollision[count];
            for (uint i = 0; i < count; i++)
            {
               TrainPlatform.PlatformCollision collision = new TrainPlatform.PlatformCollision();
               collision.x1 = BE.I16(data, idx);
               collision.y1 = BE.I16(data, idx + 2);
               collision.z1 = BE.I16(data, idx + 4);
               collision.x2 = BE.I16(data, idx + 6);
               collision.y2 = BE.I16(data, idx + 8);
               collision.z2 = BE.I16(data, idx + 0xA);
               collision.x3 = BE.I16(data, idx + 0xC);
               collision.y3 = BE.I16(data, idx + 0xE);
               collision.z3 = BE.I16(data, idx + 0x10);
               collision.h12 = BE.U16(data, idx + 0x12);
               collision.b14 = data[idx + 0x14];
               idx += 0x15;
               platform.collision[i] = collision;
            }
            count = data[idx++];
            platform.someList = new byte[count];
            for (uint i = 0; i < count; i++)
            {
               platform.someList[i] = data[idx];
               idx++;
            }
            trainPlatforms.Add(platform);
         }
      }

      // 0x6C: X/Z Collision
      // {[EE EE EE EE] {[X1 X1] [Y1 Y1] [Z1 Z1] [X2 X2] [Y2 Y2] [Z2 Z2] [X3 X3] [Y3 Y3] [Z3 Z3] [AA AA] [BB] [CC]}}
      private void decodeCollision6C(byte[] data)
      {
         uint start = BE.U32(data, 0x6C);
         uint w = BE.U16(data, 0x10);
         uint h = BE.U16(data, 0x12);
         uint count = w * h;
         uint idx = start;
         uint end;
         while (count > 0)
         {
            end = start + BE.U32(data, idx);
            idx += 4;
            CollisionGroup cg = new CollisionGroup();
            while (idx < end)
            {
               Int16 x1, y1, z1, x2, y2, z2, x3, y3, z3;
               UInt16 h12;
               x1 = BE.I16(data, idx);
               y1 = BE.I16(data, idx + 2);
               z1 = BE.I16(data, idx + 4);
               x2 = BE.I16(data, idx + 6);
               y2 = BE.I16(data, idx + 8);
               z2 = BE.I16(data, idx + 0xA);
               x3 = BE.I16(data, idx + 0xC);
               y3 = BE.I16(data, idx + 0xE);
               z3 = BE.I16(data, idx + 0x10);
               h12 = BE.U16(data, idx + 0x12);
               cg.triangles.Add(new CollisionTri(x1, y1, z1, x2, y2, z2, x3, y3, z3, h12, data[idx + 0x14], data[idx + 0x15]));
               idx += 0x16;
            }
            collisionGroups.Add(cg);
            count--;
         }
      }

      // 0x70 TODO
      private void decode70(byte[] data)
      {
         copy70 = ArraySlice(data, BE.U32(data, 0x70), BE.U32(data, 0x74));
      }

      // 0x74 TODO
      private void decode74(byte[] data)
      {
         copy74 = ArraySlice(data, BE.U32(data, 0x74), BE.U32(data, 0x78));
      }

      private void saveVertices(byte[] data)
      {
         vertData = ArraySlice(data, 0xC8, BE.U32(data, 0x20));
      }

      private byte[] ArraySlice(byte[] data, uint start, uint end)
      {
         byte[] retArr = null;
         uint length = end - start;
         if (length > 0)
         {
            retArr = new byte[length];
            Array.Copy(data, start, retArr, 0, length);
         }
         return retArr;
      }

      private static int AppendArray(byte[] dest, int offset, byte[] src)
      {
         if (src != null)
         {
            Array.Copy(src, 0, dest, offset, src.Length);
            offset += src.Length;
            return src.Length;
         }
         return 0;
      }

      public byte[] ToBytes()
      {
         // TODO: convert to MemoryStream 
         byte[] data = new byte[400 * 1024];
         int offset = 0x0;
         int first;

         foreach (UInt16 val in header.u16s)
         {
            offset += BE.ToBytes(val, data, offset);
         }
         offset += BE.ToBytes(header.gravity, data, offset);
         offset += BE.ToBytes(header.u1C, data, offset);

         // TODO: real offsets
         offset = 0x78;
         for (int i = 0; i < header.offsets.Length; i++)
         {
            if (i * 4 + 0x20 >= 0x78)
            {
               offset += BE.ToBytes(header.offsets[i], data, offset);
            }
         }

         offset = 0xC8;
         Array.Copy(vertData, 0, data, offset, vertData.Length);
         offset += vertData.Length;

         BE.ToBytes(offset, data, 0x20);
         foreach (AmmoBox ammo in ammoBoxes)
         {
            offset += BE.ToBytes(ammo.x, data, offset);
            offset += BE.ToBytes(ammo.y, data, offset);
            offset += BE.ToBytes(ammo.z, data, offset);
            offset += BE.ToBytes(ammo.type, data, offset);
         }

         BE.ToBytes(offset, data, 0x24);
         foreach (Collision24 collision in collisions)
         {
            offset += BE.ToBytes(collision.x1, data, offset);
            offset += BE.ToBytes(collision.y1, data, offset);
            offset += BE.ToBytes(collision.z1, data, offset);
            offset += BE.ToBytes(collision.x2, data, offset);
            offset += BE.ToBytes(collision.y2, data, offset);
            offset += BE.ToBytes(collision.z2, data, offset);
            offset += BE.ToBytes(collision.x3, data, offset);
            offset += BE.ToBytes(collision.y3, data, offset);
            offset += BE.ToBytes(collision.z3, data, offset);
            offset += BE.ToBytes(collision.type, data, offset);
         }

         BE.ToBytes(offset, data, 0x28);
         foreach (CommPoint comm in commPoints)
         {
            offset += BE.ToBytes(comm.x, data, offset);
            offset += BE.ToBytes(comm.y, data, offset);
            offset += BE.ToBytes(comm.z, data, offset);
            offset += BE.ToBytes(comm.h6, data, offset);
         }

         BE.ToBytes(offset, data, 0x2C);
         foreach (Object2C obj in object2Cs)
         {
            offset += BE.ToBytes(obj.w0, data, offset);
            data[offset++] = (byte)(obj.words.Length+1);
            data[offset++] = obj.b5;
            data[offset++] = obj.b6;
            data[offset++] = obj.b7;
            data[offset++] = obj.b8;
            data[offset++] = obj.b9;
            data[offset++] = obj.bA;
            data[offset++] = obj.bB;
            foreach (UInt32 word in obj.words)
            {
               offset += BE.ToBytes(word, data, offset);
            }
         }

         BE.ToBytes(offset, data, 0x30);
         first = offset;
         foreach (TerrainGroup tg in terrainGroups)
         {
            offset += BE.ToBytes(offset - first + tg.triangles.Count * 0x14 + 4, data, offset);
            foreach (TerrainTri tri in tg.triangles)
            {
               offset += BE.ToBytes(tri.x1, data, offset);
               offset += BE.ToBytes(tri.y1, data, offset);
               offset += BE.ToBytes(tri.z1, data, offset);
               offset += BE.ToBytes(tri.x2, data, offset);
               offset += BE.ToBytes(tri.y2, data, offset);
               offset += BE.ToBytes(tri.z2, data, offset);
               offset += BE.ToBytes(tri.x3, data, offset);
               offset += BE.ToBytes(tri.y3, data, offset);
               offset += BE.ToBytes(tri.z3, data, offset);
               data[offset++] = tri.b12;
               data[offset++] = tri.b13;
            }
         }

         BE.ToBytes(offset, data, 0x34);
         foreach (RDU rdu in rdus)
         {
            offset += BE.ToBytes(rdu.x, data, offset);
            offset += BE.ToBytes(rdu.y, data, offset);
            offset += BE.ToBytes(rdu.z, data, offset);
         }

         BE.ToBytes(offset, data, 0x38);
         foreach (TNTCrate tnt in tntCrates)
         {
            offset += BE.ToBytes(tnt.x, data, offset);
            offset += BE.ToBytes(tnt.y, data, offset);
            offset += BE.ToBytes(tnt.z, data, offset);
            data[offset++] = tnt.b6;
            data[offset++] = tnt.timer;
            offset += BE.ToBytes(tnt.h8, data, offset);
            offset += BE.ToBytes(tnt.hA, data, offset);
         }

         BE.ToBytes(offset, data, 0x3C);
         if (squareBlocks.Count > 1)
         {
            bool first8 = false;
            // TODO: assuming blocks match holes and are in order
            // it might be better to store them in two separate lists
            offset += BE.ToBytes((UInt16)(squareBlocks.Count / 2), data, offset);
            foreach (SquareBlock block in squareBlocks)
            {
               if (block.hole == 8  && !first8)
               {
                  offset += BE.ToBytes((UInt16)(squareBlocks.Count / 2), data, offset);
                  first8 = true;
               }
               offset += BE.ToBytes(block.x, data, offset);
               offset += BE.ToBytes(block.y, data, offset);
               offset += BE.ToBytes(block.z, data, offset);
               data[offset++] = block.type;
               data[offset++] = block.hole;
               if (block.hole == 8)
               {
                  offset += BE.ToBytes(block.extra, data, offset);
                  foreach (SquareBlock.Node node in block.nodes)
                  {
                     for (int i = 0; i < 3; i++)
                     {
                        offset += BE.ToBytes(node.x[i], data, offset);
                        offset += BE.ToBytes(node.y[i], data, offset);
                        offset += BE.ToBytes(node.z[i], data, offset);
                     }
                     Array.Copy(node.other, 0, data, offset, node.other.Length);
                     offset += node.other.Length;
                  }
               }
            }
         }

         BE.ToBytes(offset, data, 0x40);
         foreach (Bounds bound in bounds40)
         {
            offset += BE.ToBytes(bound.x1, data, offset);
            offset += BE.ToBytes(bound.z1, data, offset);
            offset += BE.ToBytes(bound.x2, data, offset);
            offset += BE.ToBytes(bound.z2, data, offset);
            offset += BE.ToBytes(bound.todo, data, offset);
         }

         BE.ToBytes(offset, data, 0x44);
         foreach (Bounds bound in bounds44)
         {
            offset += BE.ToBytes(bound.x1, data, offset);
            offset += BE.ToBytes(bound.z1, data, offset);
            offset += BE.ToBytes(bound.x2, data, offset);
            offset += BE.ToBytes(bound.z2, data, offset);
            offset += BE.ToBytes(bound.todo, data, offset);
         }

         // TODO: 0x48 real data
         BE.ToBytes(offset, data, 0x48);
         offset += AppendArray(data, offset, copy48);

         BE.ToBytes(offset, data, 0x4C);
         offset += BE.ToBytes(bounds.x1, data, offset);
         offset += BE.ToBytes(bounds.z1, data, offset);
         offset += BE.ToBytes(bounds.x2, data, offset);
         offset += BE.ToBytes(bounds.z2, data, offset);

         BE.ToBytes(offset, data, 0x50);
         foreach (Vehicle veh in vehicles)
         {
            data[offset++] = veh.type;
            offset += BE.ToBytes(veh.x, data, offset);
            offset += BE.ToBytes(veh.y, data, offset);
            offset += BE.ToBytes(veh.z, data, offset);
            offset += BE.ToBytes(veh.heading, data, offset);
         }

         BE.ToBytes(offset, data, 0x54);
         data[offset++] = carrier.speed;
         offset += BE.ToBytes(carrier.x, data, offset);
         offset += BE.ToBytes(carrier.z, data, offset);
         offset += BE.ToBytes(carrier.heading, data, offset);
         offset += BE.ToBytes(carrier.distance, data, offset);

         // 0x58 starts at half-word boundary, so pad as necessary
         if ((offset & 0x1) > 0)
         {
            data[offset++] = 0x0;
         }

         // TODO: 0x58 real data
         BE.ToBytes(offset, data, 0x58);
         offset += AppendArray(data, offset, copy58);

         BE.ToBytes(offset, data, 0x5C);
         foreach (Building b in buildings)
         {
            offset += BE.ToBytes(b.x, data, offset);
            offset += BE.ToBytes(b.y, data, offset);
            offset += BE.ToBytes(b.z, data, offset);
            offset += BE.ToBytes(b.type, data, offset);
            data[offset++] = b.counter;
            data[offset++] = b.b9;
            offset += BE.ToBytes(b.behavior, data, offset);
            offset += BE.ToBytes(b.speed, data, offset);
         }

         // TODO: 0x60 real data
         BE.ToBytes(offset, data, 0x60);
         offset += AppendArray(data, offset, copy60);

         // TODO: 0x64 real data
         BE.ToBytes(offset, data, 0x64);
         offset += AppendArray(data, offset, copy64);

         BE.ToBytes(offset, data, 0x68);
         foreach (TrainPlatform platform in trainPlatforms)
         {
            data[offset++] = platform.b0;
            data[offset++] = platform.b1;
            data[offset++] = (byte)platform.stoppingZone.Length;
            foreach (TrainPlatform.StoppingTriangle triangle in platform.stoppingZone)
            {
               offset += BE.ToBytes(triangle.x1, data, offset);
               offset += BE.ToBytes(triangle.z1, data, offset);
               offset += BE.ToBytes(triangle.x2, data, offset);
               offset += BE.ToBytes(triangle.z2, data, offset);
               offset += BE.ToBytes(triangle.x3, data, offset);
               offset += BE.ToBytes(triangle.z3, data, offset);
            }
            offset += BE.ToBytes(platform.word, data, offset);
            data[offset++] = (byte)platform.collision.Length;
            foreach (TrainPlatform.PlatformCollision collision in platform.collision)
            {
               offset += BE.ToBytes(collision.x1, data, offset);
               offset += BE.ToBytes(collision.y1, data, offset);
               offset += BE.ToBytes(collision.z1, data, offset);
               offset += BE.ToBytes(collision.x2, data, offset);
               offset += BE.ToBytes(collision.y2, data, offset);
               offset += BE.ToBytes(collision.z2, data, offset);
               offset += BE.ToBytes(collision.x3, data, offset);
               offset += BE.ToBytes(collision.y3, data, offset);
               offset += BE.ToBytes(collision.z3, data, offset);
               offset += BE.ToBytes(collision.h12, data, offset);
               data[offset++] = collision.b14;
            }
            data[offset++] = (byte)platform.someList.Length;
            foreach (byte b in platform.someList)
            {
               data[offset++] = b;
            }
         }

         BE.ToBytes(offset, data, 0x6C);
         first = offset;
         foreach (CollisionGroup cg in collisionGroups)
         {
            offset += BE.ToBytes(offset - first + cg.triangles.Count * 0x16 + 4, data, offset);
            foreach (CollisionTri tri in cg.triangles)
            {
               offset += BE.ToBytes(tri.x1, data, offset);
               offset += BE.ToBytes(tri.y1, data, offset);
               offset += BE.ToBytes(tri.z1, data, offset);
               offset += BE.ToBytes(tri.x2, data, offset);
               offset += BE.ToBytes(tri.y2, data, offset);
               offset += BE.ToBytes(tri.z2, data, offset);
               offset += BE.ToBytes(tri.x3, data, offset);
               offset += BE.ToBytes(tri.y3, data, offset);
               offset += BE.ToBytes(tri.z3, data, offset);
               offset += BE.ToBytes(tri.h12, data, offset);
               data[offset++] = tri.b14;
               data[offset++] = tri.b15;
            }
         }

         // TODO: 0x70 real data
         BE.ToBytes(offset, data, 0x70);
         offset += AppendArray(data, offset, copy70);

         // TODO: 0x74 real data
         BE.ToBytes(offset, data, 0x74);
         offset += AppendArray(data, offset, copy74);

         byte[] copy = new byte[offset];
         Array.Copy(data, copy, offset);

         return copy;
      }


      static public BlastCorpsLevel decodeLevel(byte[] levelData, byte[] displayListData)
      {
         BlastCorpsLevel level = new BlastCorpsLevel();
         level.decodeHeader(levelData);          // 0x00-0x1F
         level.saveVertices(levelData);          // 0xC8-ammo
         level.decodeAmmoBoxes(levelData);       // 0x20
         level.decodeCollision24(levelData);     // 0x24
         level.decodeCommPoints(levelData);      // 0x28
         level.decode2C(levelData);              // 0x2C TODO: name
         level.decodeTerrain(levelData);         // 0x30
         level.decodeRDUs(levelData);            // 0x34
         level.decodeTNTCrates(levelData);       // 0x38
         level.decodeSquareBlocks(levelData);    // 0x3C
         level.decodeBounds40(levelData);        // 0x40
         level.decodeBounds44(levelData);        // 0x44
         level.decode48(levelData);              // 0x48 TODO: decode these U32s
         level.decodeLevelBounds(levelData);     // 0x4C
         level.decodeVehicles(levelData);        // 0x50
         level.decodeMissileCarrier(levelData);  // 0x54
         level.decode58(levelData);              // 0x58 TODO
         level.decodeBuildings(levelData);       // 0x5C
         level.decode60(levelData);              // 0x60 TODO
         level.decode64(levelData);              // 0x64 TODO
         level.decodeTrainPlatform(levelData);   // 0x68
         level.decodeCollision6C(levelData);     // 0x6C
         level.decode70(levelData);              // 0x70 TODO
         level.decode74(levelData);              // 0x74 TODO
         // TODO: 0x78-0x9C are beyond level length and may be in display list
         level.copyLevelData = levelData;
         level.displayList = displayListData;
         return level;
      }
   }
}

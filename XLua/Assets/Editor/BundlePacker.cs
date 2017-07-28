using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
public class BundlePacker : Editor
{
  static List<string> dirsList = new List<string>();
  static List<string> filesList = new List<string>();
  static string DataPath = Application.dataPath;
  [MenuItem("AssetsBundle/Build")]
  public static void BuildBundle()
  {
    HandleLuaCode();
    // BuildPipeline.BuildAssetBundles("Assets/StreamingAssets", BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.Android);
  }
  static void HandleLuaCode()
  {
    string luaDir = DataPath + "/Lua/";
    string streamPath = Application.streamingAssetsPath;
    string luaBundlePath = streamPath + "/Lua/";
    if (Directory.Exists(luaBundlePath)) Directory.Delete(luaBundlePath,true);
    if (Directory.Exists(streamPath)) Directory.Delete(streamPath,true);
    Directory.CreateDirectory(streamPath);
    // dirsList.Clear(); filesList.Clear();
    // GetChildFile(luaDir);
    // foreach (string dir in dirsList)
    // {
    //   string streamDir = dir.Replace(luaDir, luaBundlePath);
    //   File.Copy(dir,streamDir, true);
    // }
    // foreach (string file in filesList)
    // {
    //   string streamFile = file.Replace(luaDir, "");
    //   File.Copy(file, streamFile, true);
    // }
  }
  //处理子类文件
  static void GetChildFile(string dirPath)
  {
    string[] dirs = Directory.GetDirectories(dirPath);
    string[] files = Directory.GetFiles(dirPath);
    foreach (string file in files)
    {
      if (file.EndsWith(".meta")) continue;
      filesList.Add(file.Replace('\\', '/'));
    }
    foreach (string dir in dirs)
    {
      dirsList.Add(dir.Replace('\\', '/'));
      GetChildFile(dir);
    }
  }
}

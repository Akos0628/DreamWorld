using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dummiesman;
using UnityEngine.Networking;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.VisualScripting;
using Pcx;
using System.Linq;

public class SpawnItem : MonoBehaviour
{
	private string path = "G:\\Work\\mesh.ply";
	public GameObject go;

	public void Start()
	{
		Load();
		/*var mesh = new Mesh();
		mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
		mesh.SetVertices(new Vector3[] { new Vector3(0, 1, 0), new Vector3(1, 1, 0), new Vector3(0, 1, 1) });
		mesh.SetColors(new Color[] { Color.yellow, Color.green, Color.red });
		mesh.SetTriangles(new int[] { 0,2,1 }, 0);
		mesh.RecalculateBounds();
		mesh.RecalculateNormals();
		mesh.RecalculateTangents();

		mesh.GetTriangles(0);

		mesh.UploadMeshData(true);



		go = new GameObject("cloud");
		go.transform.position = new Vector3(0, 1, 0);

		var mf = go.AddComponent<MeshFilter>();
		mf.mesh = mesh;

		var mr = go.AddComponent<MeshRenderer>();
		mr.material = new Material(Shader.Find("Universal Render Pipeline/Particles/Unlit"));

		var mc = go.AddComponent<MeshCollider>();
		mc.convex = true;
		mc.sharedMesh = mesh;

		var rb = go.AddComponent<Rigidbody>();
		rb.useGravity = false;

		var xrGrabInt = go.AddComponent<XRGrabInteractable>();
		xrGrabInt.interactionLayers = 12; // layer 3 and 4
		xrGrabInt.useDynamicAttach = true;*/
	}

	public void OnClickOpen()
	{
		Load();
	}

	public async void Load()
	{
		var importer = new PlyImporterRuntime();
		var mesh = importer.ImportAsMesh(path);

		//var cloudData = importer.ImportAsPointCloudData(path);


		go = new GameObject(mesh.name);
		go.transform.position = new Vector3(0, 1, 0);

		var mf = go.AddComponent<MeshFilter>();
		mf.mesh = mesh;

		var mr = go.AddComponent<MeshRenderer>();
		mr.material = new Material(Shader.Find("Universal Render Pipeline/Particles/Simple Lit"));

		//var cr = go.AddComponent<PointCloudRenderer>();
		//cr.sourceData = cloudData;
		//cr.pointSize = 0.003f;

		var mc = go.AddComponent<MeshCollider>();
		mc.convex = true;
		mc.sharedMesh = mesh;

		var rb = go.AddComponent<Rigidbody>();

		var xrGrabInt = go.AddComponent<XRGrabInteractable>();
		xrGrabInt.interactionLayers = 12; // layer 3 and 4
		xrGrabInt.useDynamicAttach = true;
	}

	//   public GameObject model;
	//   public XRInteractionManager interactionManager;

	//   private string path = "G:\\Work\\proba\\idk";

	//void Start()
	//{
	//	StartCoroutine(OutputRoutineOpen(path + ".obj", path + ".mtl"));
	//}

	//public void OnClickOpen()
	//   {
	//       StartCoroutine(OutputRoutineOpen(path+".obj", path+".mtl"));
	//   }

	//   private IEnumerator OutputRoutineOpen(string objUrl, string mtlUrl)
	//   {
	//       UnityWebRequest www1 = UnityWebRequest.Get(objUrl);
	//       UnityWebRequest www2 = UnityWebRequest.Get(mtlUrl);
	//       yield return www1.SendWebRequest();
	//       yield return www2.SendWebRequest();
	//       if(www1.result != UnityWebRequest.Result.Success || www2.result != UnityWebRequest.Result.Success)
	//       {
	//           Debug.Log("WWW ERROR: " + www1.error);
	//       }
	//       else
	//       {
	//           MemoryStream objStream = new MemoryStream(Encoding.UTF8.GetBytes(www1.downloadHandler.text));
	//           MemoryStream mtlStream = new MemoryStream(Encoding.UTF8.GetBytes(www2.downloadHandler.text));
	//           if(model != null)
	//           {
	//               Destroy(model);
	//           }
	//           model = new OBJLoader().Load(objStream, mtlStream);
	//           model.transform.localScale = new Vector3(-1f, 1f, 1f);

	//           model.transform.position = new Vector3(0, 0, 0);

	//           var child = model.transform.GetChild(0);

	//		MeshFilter filter = child.GetComponent<MeshFilter>();
	//           //Debug.Log("aaaaaaa");

	//		//MeshCollider collider = child.AddComponent<MeshCollider>();
	//		//collider.convex = true;
	//           //collider.sharedMesh = filter.sharedMesh;

	//           //Rigidbody rb = child.AddComponent<Rigidbody>();
	//	}
	//   }


}

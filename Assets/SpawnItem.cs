using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.XR.Interaction.Toolkit;
using Pcx;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit.Transformers;
using UnityEditor;

public class SpawnItem : MonoBehaviour
{
	public XRInteractionManager InteractionManager;
	public GameObject go;
	public string url = "http://localhost:5000/";
	public TMP_InputField prompt;
	private static int count = 0;

	private static List<GameObject> list = new List<GameObject>();

	public void Start()
	{
		//StartCoroutine(GeneratNew());
		Physics.IgnoreLayerCollision(8, 7);
		Physics.IgnoreLayerCollision(9, 7);
	}

	public void OnClickGenerate()
	{
		StartCoroutine(GeneratNew());
	}

	public void OnClickDuplicate()
	{
		StartCoroutine(Duplicate());
	}

	public IEnumerator GeneratNew()
	{
		var jsonBody = "{ \"prompt\": \"" + prompt.text + "\" }";
		Debug.Log(url);

		byte[] rawBody = Encoding.UTF8.GetBytes(jsonBody);

		UnityWebRequest www = new UnityWebRequest(url, "POST");
		www.uploadHandler = new UploadHandlerRaw(rawBody);
		www.downloadHandler = new DownloadHandlerBuffer();
		www.SetRequestHeader("Content-Type", "application/json");

		yield return www.SendWebRequest();

		if(www.result != UnityWebRequest.Result.Success)
		{
			Debug.Log(www.downloadHandler.text);
		}
		else
		{
			var stream = new MemoryStream(www.downloadHandler.data);

			Import(stream);
		}

		www.Dispose();
	}

	public IEnumerator Duplicate()
	{
		Debug.Log(url + "test");
		UnityWebRequest www = UnityWebRequest.Get(url + "test");

		yield return www.SendWebRequest();

		if (www.result != UnityWebRequest.Result.Success)
		{
			Debug.Log(www.downloadHandler.text);
		}
		else
		{
			var stream = new MemoryStream(www.downloadHandler.data);

			Import(stream);
		}

		www.Dispose();
	}

	private void Import(MemoryStream stream)
	{
		PlyImporterRuntime importer = new PlyImporterRuntime();
		Mesh mesh = importer.ImportFromStreamAsMesh(stream);

		//AssetDatabase.CreateAsset(mesh, "Assets/mesh1.asset");

		mesh.name = "mesh" + count;
		go = new GameObject("object" + count);
		count += 1;

		go.transform.position = new Vector3(0, 1, 0);

		var mf = go.AddComponent<MeshFilter>();
		mf.mesh = mesh;

		var mr = go.AddComponent<MeshRenderer>();
		mr.material = new Material(Shader.Find("Universal Render Pipeline/Particles/Simple Lit"));

		var mc = go.AddComponent<MeshCollider>();
		mc.convex = true;
		mc.sharedMesh = null;
		mc.sharedMesh = mesh;

		var rb = go.AddComponent<Rigidbody>();
		rb.useGravity = false;
		rb.drag = 1f;
		rb.angularDrag = 1f;

		var xrGrabTransf = go.AddComponent<XRGeneralGrabTransformer>();
		xrGrabTransf.allowTwoHandedScaling = true;
		xrGrabTransf.minimumScaleRatio = 0.01f;
		xrGrabTransf.maximumScaleRatio = 10f;

		var xrGrabInt = go.AddComponent<XRGrabInteractable>();
		xrGrabInt.interactionLayers = 4;//12; // layer 2 and 3
		xrGrabInt.useDynamicAttach = true;
		xrGrabInt.throwOnDetach = false;
		xrGrabInt.selectMode = InteractableSelectMode.Multiple;
		xrGrabInt.MoveMultipleGrabTransformerTo(xrGrabTransf, 0);
		xrGrabInt.interactionManager = InteractionManager;

		mesh.UploadMeshData(true);

		go.layer = 7;

		list.Add(go);
		foreach(var obj in list)
		{
			Physics.IgnoreCollision(obj.GetComponent<Collider>(), mc);
		}
	}
}

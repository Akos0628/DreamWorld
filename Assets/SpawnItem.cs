using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dummiesman;
using UnityEngine.Networking;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.XR.Interaction.Toolkit;

public class SpawnItem : MonoBehaviour
{
    public GameObject model;
    public XRInteractionManager interactionManager;

	public async void OnClickOpen()
    {
        StartCoroutine(OutputRoutineOpen("G:\\Work\\couch\\couch.obj"));
    }

    private IEnumerator OutputRoutineOpen(string url)
    {
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();
        if(www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("WWW ERROR: " + www.error);
        }
        else
        {
            MemoryStream textStream = new MemoryStream(Encoding.UTF8.GetBytes(www.downloadHandler.text));
            if(model != null)
            {
                Destroy(model);
            }
            model = new OBJLoader().Load(textStream);
            model.transform.localScale = new Vector3(-0.001f, 0.001f, 0.001f);

            model.transform.position = new Vector3(0, 0, 0);
		}
    }


}

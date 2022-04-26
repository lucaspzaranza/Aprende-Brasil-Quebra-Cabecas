using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

/// <summary>
/// Vou usar esse script se eu precisar carregar as imagens do jogo remotamente
/// pra diminuir o tamanho do projeto. Mas por hora, tá tranquilo.
/// </summary>
public class BundleLoader : MonoBehaviour
{
    public string assetName = "Tela inicial.png";
    private string bundleUrl = string.Empty;

    void Start() 
    {
        bundleUrl = Application.dataPath + "/StreamingAssets/desktop";
        using (WWW web = new WWW(bundleUrl))
        {
            AssetBundle remoteAssetBundle = web.assetBundle;
            if (remoteAssetBundle == null)
            {
                Debug.LogError("Failed to download AssetBundle!");
                return;
            }

            var test = remoteAssetBundle.LoadAsset<Sprite>(assetName);

            print(test);
            remoteAssetBundle.Unload(false);
        }
    }
}
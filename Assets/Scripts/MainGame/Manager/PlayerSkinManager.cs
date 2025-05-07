using UnityEngine;

public class PlayerSkinManager : MonoBehaviour
{
    public Transform skinContainer;

    GameObject currentSkin;

  
    public void ChangeSkin(GameObject skinPrefab)
    {
       
        foreach (Transform child in skinContainer)
            Destroy(child.gameObject);

        currentSkin = Instantiate(skinPrefab, skinContainer);
        currentSkin.transform.localPosition = Vector3.zero;
        currentSkin.transform.localRotation = Quaternion.identity;
        currentSkin.transform.localScale = Vector3.one;
    }
}

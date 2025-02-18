using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;

public class BackgroundLoader : MonoBehaviour
{
    public SpriteRenderer backgroundRenderer; // ����Ƽ���� �Ҵ��� Sprite Renderer

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern int SystemParametersInfo(int uAction, int uParam, System.Text.StringBuilder lpvParam, int fuWinIni);
    private const int SPI_GETDESKWALLPAPER = 0x0073;

    private void Start()
    {
        string path = GetWallpaperPath();
        Debug.Log(path); // ��� Ȯ��

        if (!string.IsNullOrEmpty(path) && File.Exists(path))
        {
            StartCoroutine(LoadWallpaper(path));
        }
        else
        {
            Debug.LogError("���ȭ���� �ܻ��̰ų� ������ ã�� �� �����ϴ�.");
            Debug.LogError("�⺻ �ܻ��� �����ϰڽ��ϴ�.");
            ApplySolidColorBackground(Color.blue);
        }
    }

    private string GetWallpaperPath()
    {
        System.Text.StringBuilder path = new System.Text.StringBuilder(200);
        SystemParametersInfo(SPI_GETDESKWALLPAPER, path.Capacity, path, 0);
        return path.ToString();
    }

    private IEnumerator LoadWallpaper(string path)
    {
        byte[] imageBytes = File.ReadAllBytes(path);
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(imageBytes);
        texture.Apply();

        Debug.Log("�̹��� �ε� ����!");

        // Texture�� Sprite�� ��ȯ
        Sprite sprite = TextureToSprite(texture);
        backgroundRenderer.sprite = sprite;

        // ī�޶� ũ�⿡ �°� ����
        AdjustBackgroundSize(sprite);

        yield return null;
    }

    private Sprite TextureToSprite(Texture2D texture)
    {
        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
    }

    private void AdjustBackgroundSize(Sprite sprite)
    {
        if (sprite == null) return;

        // ī�޶��� ũ�� ���ϱ� (2D Orthographic ī�޶� ����)
        float screenHeight = Camera.main.orthographicSize * 2.0f;
        float screenWidth = screenHeight * Screen.width / Screen.height;

        // �̹����� ���� ����/���� ���� ����
        float imageWidth = sprite.bounds.size.x;
        float imageHeight = sprite.bounds.size.y;
        float imageAspect = imageWidth / imageHeight; // ���� �̹��� ����
        float screenAspect = screenWidth / screenHeight; // ȭ�� ����

        // ���� ���߱�
        float scaleX, scaleY;
        if (imageAspect > screenAspect)
        {
            // �̹����� �� ���� ��� - ���̿� ���缭 ũ�� ����
            scaleY = screenHeight / imageHeight;
            scaleX = scaleY;
        }
        else
        {
            // �̹����� �� ������ ��� - ���ο� ���缭 ũ�� ����
            scaleX = screenWidth / imageWidth;
            scaleY = scaleX;
        }

        // ũ�� ����
        backgroundRenderer.transform.localScale = new Vector3(scaleX, scaleY, 1);
        backgroundRenderer.transform.position = new Vector3(0, 0, 10); // ī�޶� �ȿ� ��ġ
    }

    private void ApplySolidColorBackground(Color bgColor)
    {
        Texture2D solidTexture = new Texture2D(1, 1);
        solidTexture.SetPixel(0, 0, bgColor);
        solidTexture.Apply();

        Sprite solidSprite = Sprite.Create(solidTexture, new Rect(0, 0, 1, 1), new Vector2(0.5f, 0.5f));
        backgroundRenderer.sprite = solidSprite;
        backgroundRenderer.transform.localScale = new Vector3(20, 20, 1); // ȭ�� ũ�⿡ �°� ����
    }


}

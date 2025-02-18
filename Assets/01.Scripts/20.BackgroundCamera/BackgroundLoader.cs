using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;

public class BackgroundLoader : MonoBehaviour
{
    public SpriteRenderer backgroundRenderer; // 유니티에서 할당할 Sprite Renderer

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern int SystemParametersInfo(int uAction, int uParam, System.Text.StringBuilder lpvParam, int fuWinIni);
    private const int SPI_GETDESKWALLPAPER = 0x0073;

    private void Start()
    {
        string path = GetWallpaperPath();
        Debug.Log(path); // 경로 확인

        if (!string.IsNullOrEmpty(path) && File.Exists(path))
        {
            StartCoroutine(LoadWallpaper(path));
        }
        else
        {
            Debug.LogError("배경화면이 단색이거나 파일을 찾을 수 없습니다.");
            Debug.LogError("기본 단색을 적용하겠습니다.");
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

        Debug.Log("이미지 로드 성공!");

        // Texture를 Sprite로 변환
        Sprite sprite = TextureToSprite(texture);
        backgroundRenderer.sprite = sprite;

        // 카메라 크기에 맞게 조정
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

        // 카메라의 크기 구하기 (2D Orthographic 카메라 기준)
        float screenHeight = Camera.main.orthographicSize * 2.0f;
        float screenWidth = screenHeight * Screen.width / Screen.height;

        // 이미지의 원래 가로/세로 비율 유지
        float imageWidth = sprite.bounds.size.x;
        float imageHeight = sprite.bounds.size.y;
        float imageAspect = imageWidth / imageHeight; // 원본 이미지 비율
        float screenAspect = screenWidth / screenHeight; // 화면 비율

        // 비율 맞추기
        float scaleX, scaleY;
        if (imageAspect > screenAspect)
        {
            // 이미지가 더 넓을 경우 - 높이에 맞춰서 크기 조정
            scaleY = screenHeight / imageHeight;
            scaleX = scaleY;
        }
        else
        {
            // 이미지가 더 길쭉할 경우 - 가로에 맞춰서 크기 조정
            scaleX = screenWidth / imageWidth;
            scaleY = scaleX;
        }

        // 크기 적용
        backgroundRenderer.transform.localScale = new Vector3(scaleX, scaleY, 1);
        backgroundRenderer.transform.position = new Vector3(0, 0, 10); // 카메라 안에 배치
    }

    private void ApplySolidColorBackground(Color bgColor)
    {
        Texture2D solidTexture = new Texture2D(1, 1);
        solidTexture.SetPixel(0, 0, bgColor);
        solidTexture.Apply();

        Sprite solidSprite = Sprite.Create(solidTexture, new Rect(0, 0, 1, 1), new Vector2(0.5f, 0.5f));
        backgroundRenderer.sprite = solidSprite;
        backgroundRenderer.transform.localScale = new Vector3(20, 20, 1); // 화면 크기에 맞게 조정
    }


}

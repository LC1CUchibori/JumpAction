using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowDraw : MonoBehaviour
{
    [SerializeField] private Image _arrowImage;

    private Vector3 _clickPosition;

    void Start()
    {
        // 初期状態で矢印の画像を非表示にする
        _arrowImage.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _clickPosition = Input.mousePosition;
            // マウスが押された時に矢印の画像を表示する
            _arrowImage.enabled = true;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 dist = _clickPosition - Input.mousePosition;
            // ベクトルの長さを算出
            float size = dist.magnitude;
            // ベクトルから角度（ラジアン）を算出
            float angleRad = Mathf.Atan2(dist.y, dist.x);
            // 矢印の画像をクリックした場所に移動
            _arrowImage.rectTransform.position = _clickPosition;
            // ベクトルから算出した角度を度数法に変換して矢印の画像を回転
            _arrowImage.rectTransform.rotation = Quaternion.Euler(0, 0, angleRad * Mathf.Rad2Deg);
            // ドラッグした距離に合わせて矢印の画像の大きさを変更
            _arrowImage.rectTransform.sizeDelta = new Vector2(size, size);
        }

        if (Input.GetMouseButtonUp(0))
        {
            // マウスボタンが離された時に矢印の画像を非表示にする
            _arrowImage.enabled = false;
        }
    }
}

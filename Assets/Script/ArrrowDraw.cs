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
        // ������ԂŖ��̉摜���\���ɂ���
        _arrowImage.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _clickPosition = Input.mousePosition;
            // �}�E�X�������ꂽ���ɖ��̉摜��\������
            _arrowImage.enabled = true;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 dist = _clickPosition - Input.mousePosition;
            // �x�N�g���̒������Z�o
            float size = dist.magnitude;
            // �x�N�g������p�x�i���W�A���j���Z�o
            float angleRad = Mathf.Atan2(dist.y, dist.x);
            // ���̉摜���N���b�N�����ꏊ�Ɉړ�
            _arrowImage.rectTransform.position = _clickPosition;
            // �x�N�g������Z�o�����p�x��x���@�ɕϊ����Ė��̉摜����]
            _arrowImage.rectTransform.rotation = Quaternion.Euler(0, 0, angleRad * Mathf.Rad2Deg);
            // �h���b�O���������ɍ��킹�Ė��̉摜�̑傫����ύX
            _arrowImage.rectTransform.sizeDelta = new Vector2(size, size);
        }

        if (Input.GetMouseButtonUp(0))
        {
            // �}�E�X�{�^���������ꂽ���ɖ��̉摜���\���ɂ���
            _arrowImage.enabled = false;
        }
    }
}

using UnityEngine;

public class WallTransparenter : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;

    [SerializeField] private LayerMask _wallLayer;

    [SerializeField] private float _rayDirectionYOffset = 3;

    private Vector3 _rayCastDirection;

    private Material _wallMaterial;

    private bool _wallsAreTransparent = false;

    private void Start()
    {
        _wallMaterial = Resources.Load($"Materials/LowerWallsMaterial", typeof(Material)) as Material;

        if (_wallMaterial == null)
        {
            Debug.LogWarning("Did not found LowerWallsMaterial");
            return;
        }

        _wallMaterial.ToOpaqueMode();
        _wallMaterial.ChangeAlpha(1f);
    }

    private void Update()
    {
        MakeWallsTransparentIfNeeded();
    }

    private void MakeWallsTransparentIfNeeded()
    {
        if (_wallMaterial == null)
            return;

        var directionToPlayer = Player.Instance.transform.position - _cameraTransform.position;
        _rayCastDirection = new Vector3(directionToPlayer.x, directionToPlayer.y - _rayDirectionYOffset, directionToPlayer.z);

        if (Physics.Raycast(_cameraTransform.position, _rayCastDirection, Mathf.Infinity, _wallLayer))
        {
            if (_wallsAreTransparent)
                return;

            Debug.Log("Walls are transparent now");
            ChangeWallsTransparency(true);
        }
        else
        {
            if (!_wallsAreTransparent)
                return;

            Debug.Log("Walls aren't transparent now");
            ChangeWallsTransparency(false);
        }
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawRay(_cameraTransform.position, _rayCastDirection * 100);
    //}

    private void ChangeWallsTransparency(bool transparent)
    {
        if (transparent)
        {
            _wallMaterial.ToFadeMode();
            _wallMaterial.ChangeAlpha(0.5f);
            _wallsAreTransparent = true;
        }
        else
        {
            _wallMaterial.ToOpaqueMode();
            _wallMaterial.ChangeAlpha(1f);
            _wallsAreTransparent = false;
        }
    }

    private void OnApplicationQuit()
    {
        _wallMaterial.ToOpaqueMode();
        _wallMaterial.ChangeAlpha(1f);
    }
}

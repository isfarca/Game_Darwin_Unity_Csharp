using UnityEngine;
using UnityEngine.UI;

//script lieg auf leerem gameObjekt
public class SpecialAbilities : MonoBehaviour 
{
    // Declare variables.
    private int _cooldown, _duration;
    private GameObject _player;

    private int _spriteCount, _spriteSwitchByFrame, _coolDownResultForSpriteSwitch;
    [SerializeField] private GameObject _dnaGameObject;
    private Image _dnaImage;
    private Button _dnaButton;
    [SerializeField] private Sprite[] _dnaSprites;


    private void Start()
    {
        //find player Object
        _player = GameObject.FindGameObjectWithTag("Player");

        _cooldown = _duration = 0;
        ElephantActive = FishActive = HawkActive = RhinoActive = TurtleActive = false;

        _spriteCount = _spriteSwitchByFrame = _coolDownResultForSpriteSwitch = 0;
        _dnaImage = _dnaGameObject.GetComponent<Image>();
        _dnaButton = _dnaGameObject.GetComponent<Button>();
    }
    
    //ability 1
    public void ElephantAbility()
    {
        // Deactivate all abilities with not durations.
        FishActive = false;

        // Get the zero dna sprite.
        _spriteCount = 0;
        _dnaImage.sprite = _dnaSprites[_spriteCount];
        
        //equals 3 seconds
        _duration = 180;
        //equals 9 seconds
        _cooldown = 540;

        _spriteSwitchByFrame = _cooldown / _dnaSprites.Length;
        _coolDownResultForSpriteSwitch = _cooldown - _spriteSwitchByFrame;
        
        ElephantActive = true;
        //speed up
        _player.GetComponent<MovementLogic>().PlayerHorizontalSpeed = 400.0f;
        //play sound and debug
        //SimpleAudioEngine::getInstance()->playEffect(CHARGE_SFX);
        
        //play sound and debug
        //SimpleAudioEngine::getInstance()->playEffect(TRAMPLE_SFX);
    }
    
    //ability 2
    public void FishAbility()
    {
        //check global bool and if ability is inactive
        if (FishActive == false)
        {
            FishActive = true;
        }
        //deactivate if already active
        else
        {
            FishActive = false;

            //restore default values for jump and gravity
            //slow falling
            _player.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
            //slow jumping
            _player.GetComponent<ActionJumpLogic>().JumpForce = 5.0f;
            //jump always enabled
            _player.GetComponent<ActionJumpLogic>().IsGrounded = true;
        }
        //play sound and debug
        //SimpleAudioEngine::getInstance()->playEffect(SWIM_SFX);
    }

    //ability 3
    public void HawkAbility()
    {
        // Deactivate all abilities with not durations.
        FishActive = false;
        
        // Get the zero dna sprite.
        _spriteCount = 0;
        _dnaImage.sprite = _dnaSprites[_spriteCount];
        
        //equals 5 seconds
        _duration = 300;
        //equals 15 seconds
        _cooldown = 900;
        
        _spriteSwitchByFrame = _cooldown / _dnaSprites.Length;
        _coolDownResultForSpriteSwitch = _cooldown - _spriteSwitchByFrame;
        
        HawkActive = true;
        //set new values for jump and gravity
        //slow falling
        _player.GetComponent<Rigidbody2D>().gravityScale = 0.1f;
        //slow jumping
        _player.GetComponent<ActionJumpLogic>().JumpForce = 10.0f;
        //stop current move-force
        _player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //play sound and debug
        //SimpleAudioEngine::getInstance()->playEffect(FLY_SFX);    
    }

    //ability 4
    public void RhinoAbility()
    {
        // Deactivate all abilities with not durations.
        FishActive = false;
        
        // Get the zero dna sprite.
        _spriteCount = 0;
        _dnaImage.sprite = _dnaSprites[_spriteCount];
        
        //equals 3 seconds
        _duration = 180;
        //equals 9 seconds
        _cooldown = 540;
        
        _spriteSwitchByFrame = _cooldown / _dnaSprites.Length;
        _coolDownResultForSpriteSwitch = _cooldown - _spriteSwitchByFrame;
        
        RhinoActive = true;
        //speed up
        _player.GetComponent<MovementLogic>().PlayerHorizontalSpeed = 500.0f;
        //play sound and debug
        //SimpleAudioEngine::getInstance()->playEffect(CHARGE_SFX);
    }

    //ability 5
    public void TurtleAbility()
    {
        // Deactivate all abilities with not durations.
        FishActive = false;
        
        // Get the zero dna sprite.
        _spriteCount = 0;
        _dnaImage.sprite = _dnaSprites[_spriteCount];
        
        //equals 4 seconds
        _duration = 240;
        //equels 12 seconds
        _cooldown = 720;
        
        _spriteSwitchByFrame = _cooldown / _dnaSprites.Length;
        _coolDownResultForSpriteSwitch = _cooldown - _spriteSwitchByFrame;
        
        TurtleActive = true;
        //Health::InvulnerableStart();
        //play sound and debug
        //SimpleAudioEngine::getInstance()->playEffect(HOLE_UP_SFX);
    }

    //to manage cooldowns and durations
    private void Update()
    {
        //cooldown
        if (_cooldown > 0)
        {
            _dnaImage.raycastTarget = _dnaButton.interactable = false;
            _cooldown--;

            if (_cooldown < _coolDownResultForSpriteSwitch)
            {
                _coolDownResultForSpriteSwitch -= _spriteSwitchByFrame;
                _spriteCount++;
                if (_spriteCount < _dnaSprites.Length)
                    _dnaImage.sprite = _dnaSprites[_spriteCount];
            }
        }
        else
        {
            _dnaImage.raycastTarget = _dnaButton.interactable = true;
            _dnaGameObject.GetComponent<Dna>().IsSpecialButtonClicked = false;
        }

        //duration
        if (_duration > 0)
            _duration--;
        else
        {
            // Set default values for player.
            if (ElephantActive)
            {
                ElephantActive = false;
                
                _player.GetComponent<MovementLogic>().PlayerHorizontalSpeed = 300.0f;
            }
            else if (HawkActive)
            {
                HawkActive = false;
                
                _player.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
                _player.GetComponent<ActionJumpLogic>().JumpForce = 5.0f;
            }
            else if (RhinoActive)
            {
                RhinoActive = false;
                
                _player.GetComponent<MovementLogic>().PlayerHorizontalSpeed = 300.0f;
            }
            else if (TurtleActive)
            {
                TurtleActive = false;
                
                Debug.Log("Return to normal health");
            }
        }
    }

    public bool ElephantActive { get; private set; }
    public bool FishActive { get; private set; }
    public bool HawkActive { get; private set; }
    public bool RhinoActive { get; private set; }
    public bool TurtleActive { get; private set; }
}
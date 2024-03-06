# Sample Code, Progammer Hugh

     이 프로젝트는 포트폴리오를 위한 샘플 코드이며,
     Unity 를 사용한 게임 프로젝트에서 공통으로 사용 할 수 있는 기본적인 설계를 목적으로 하고 있습니다.

### 샘플 프로젝트 구조 설계 문서
[https://docs.google.com/presentation/d/11Ot5OcwBiRVdSFKuL1vLpspXFzaQem4ZAc3gMRi8MNE/edit?usp=sharing](https://docs.google.com/presentation/d/11Ot5OcwBiRVdSFKuL1vLpspXFzaQem4ZAc3gMRi8MNE/edit?usp=sharing)


-----------------------------------------------------------------------------------------------------------------------------

## 네이밍 규칙
| 표기법     |    설명                                                                                                      |
|--------|-----------------------------------------------------------------------------------------------------------------------------|
| Pascal        |    단어의 첫 시작을 항상 대문자로 사용하는 표기법                                                                                        |
| camel        |    제일 처음의 단어를 소문자로 시작하고, 이후 이어지는 단어들의 시작은 대문자로 작성하는 표기법                                                                                     |
| SCREAM_SNAKE        |       모든 단어를 대문자로 표기하고, 단어 사이를 ' _ ' 로 연결시키는 표기법                                            |

-----------------------------------------------------------------------------------------------------------------------------

| 구분     | 표기법           | 예시                                                                                                           |
|--------|---------------|--------------------------------------------------------------------------------------------------------------|
| 구조체명   | Pascal        | struct UserData                                                                                              |
| 클래스명   | Pascal        | class GameManager                                                                                            |
| 함수명    | Pascal        | public void AddPlayerData(PlayerData _playerData) / public PlayerData GetPlayerData()                                                      |
| 프로퍼티명  | Pascal        | public static bool IsLoadingFinish { get { return Instance != null; } }  |
| 멤버변수명  | camel         | List<UInt64, PlayerData> currentPlayers = new ();                                                      |
| 지역변수명  | camel         | int _index;                                                                                                   |
| 외부변수명  | camel         | int _totalCount;                                                                                              |
| 정의값    | SCREAM_SNAKE  | public const float SCREEN_DEFAULT_WIDTH = 1920f;                                                             |
| Enum 값 | SCREAM_SNAKE  | public enum TYPE_SOUND                                                                                       |

-----------------------------------------------------------------------------------------------------------------------------


## 예외 규칙

Array :	names;

List : nameList;

Dictionary : nameDic;

-----------------------------------------------------------------------------------------------------------------------------

## 세부 규칙

인터페이스를 선언할 때는 제일 앞에 I(대문자 i)를 붙이고, 이후 오는 단어는 대문자로 시작한다. (ex. IEnumarator)

Bool 값은 대부분 어떤 객체의 상태를 나타냄으로, 이는 함수의 형태와 같다고 할 수 있다.
따라서, Bool값을 반환하는 함수, 프로퍼티, 변수는 모두 'Is' 접두사를 사용한다.

     
파일 이름은 대소문자까지 포함해서 반드시 클래스 이름과 일치해야 한다.		

특정한 키워드(ex. int, float, string)를 변수 이름에 사용하지 않는다.			

외부 변수명(인자)과 지역 변수명은 '_' 로 시작한다.

클래스명, 메서드명, 속성명 등의 명칭에 미리 약속되지 않은 줄임말을 사용하지 않는다.

여러 파일이 하나의 클래스를 이룰 때(partial), 파일 이름은 클래스 이름으로 시작하고, 그 뒤에 기능별 세부 항목 이름을 붙인다.

      ex. GameManager.cs / GameManager_Field.cs / GameManager_Scene.cs

함수이름은 특정한 행동을 나타내는 동사의 형태로 짓는다.

      ex. Get / Set / Open / Close / Initialize / Save / Load / Create / Destroy 등
      > 어떠한 특정한 [명사] 에 대한 행동을 요청하는 경우, 동사+명사의 형태로 짓는다. (ex. SaveInventoryData, GetZoneData)

정의값 또는 데이터 클래스들은 코드를 필요없이 길어지게 한다. 하나의 스크립트로 모아 관리한다.

      > 데이터 클래스에 대한 데이터 입력 또는 어떤 처리에 대한 부분도 되도록 클래스 내부에 넣어서 구현한다 (객체 지향 / 역할 지정)


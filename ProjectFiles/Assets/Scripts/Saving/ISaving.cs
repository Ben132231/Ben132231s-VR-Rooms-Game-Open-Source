using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaving
{
    void Load();
    void Save();
    void FinishSave();
}

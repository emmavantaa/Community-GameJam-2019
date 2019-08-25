﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void PlayerInRange();
    void Interact();
    void PlayerOutRange();
    string GetName();
}

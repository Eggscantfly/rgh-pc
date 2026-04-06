using System;
using System.Threading;
using Microsoft.DirectX.DirectInput;

namespace Launcher
{
	// Token: 0x0200000C RID: 12
	public class Joypad
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x0600005E RID: 94 RVA: 0x00004A52 File Offset: 0x00003A52
		// (remove) Token: 0x0600005F RID: 95 RVA: 0x00004A6B File Offset: 0x00003A6B
		public event JoypadHandler JoypadPress;

		// Token: 0x06000060 RID: 96 RVA: 0x00004A84 File Offset: 0x00003A84
		public Joypad()
		{
			this.WAIT_FOR[0] = this.JOYSTICK_EVENT;
			this.joyDevice = Joypad.GetJoypadDevice();
			Thread thread = new Thread(new ThreadStart(this.JoyPress));
			thread.Start();
			this.joyDevice.SetEventNotification(this.JOYSTICK_EVENT);
			this.joyDevice.Acquire();
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00004AFC File Offset: 0x00003AFC
		public static Device GetJoypadDevice()
		{
			DeviceList devices = Manager.GetDevices(DeviceType.Joystick, EnumDevicesFlags.AttachedOnly);
			if (devices.Count > 0)
			{
				devices.MoveNext();
				object obj = devices.Current;
				return new Device(((DeviceInstance)obj).InstanceGuid);
			}
			return null;
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00004B40 File Offset: 0x00003B40
		public void Update()
		{
			this.joyDevice.Poll();
			this.state = this.joyDevice.CurrentJoystickState.GetButtons();
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00004B74 File Offset: 0x00003B74
		public int GetJoypadButtonDown()
		{
			for (int i = 0; i < this.state.Length; i++)
			{
				if (this.state[i] != 0)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00004BA1 File Offset: 0x00003BA1
		private void JoyPress()
		{
			for (;;)
			{
				WaitHandle.WaitAll(this.WAIT_FOR);
				this.Update();
				if (this.GetJoypadButtonDown() != -1)
				{
					this.JoypadPress();
				}
			}
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00004BCA File Offset: 0x00003BCA
		private void OnJoypadPress()
		{
		}

		// Token: 0x0400003E RID: 62
		private AutoResetEvent JOYSTICK_EVENT = new AutoResetEvent(true);

		// Token: 0x0400003F RID: 63
		private WaitHandle[] WAIT_FOR = new WaitHandle[1];

		// Token: 0x04000040 RID: 64
		private Device joyDevice;

		// Token: 0x04000041 RID: 65
		private byte[] state;
	}
}

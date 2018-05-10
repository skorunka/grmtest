namespace Rr.Solutions.Grm.Entities
{
	using System;

	[Flags]
	public enum MusicUsage
	{
		DigitalDownload = 1 << 0,
		Streaming = 1 << 1
	}
}

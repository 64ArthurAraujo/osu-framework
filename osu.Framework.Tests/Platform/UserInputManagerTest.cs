// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using NUnit.Framework;
using osu.Framework.Graphics;
using osu.Framework.Testing;

namespace osu.Framework.Tests.Platform
{
    [TestFixture]
    public class UserInputManagerTest
    {
        [Test]
        public void IsAliveTest()
        {
            using (var client = new TestHeadlessGameHost(@"client", true))
            {
                var testGame = new TestTestGame();
                client.Run(testGame);
                Assert.IsTrue(testGame.IsRootAlive);
            }
        }

        private class TestHeadlessGameHost : TestRunHeadlessGameHost
        {
            public Drawable CurrentRoot => Root;

            public TestHeadlessGameHost(string hostname, bool bindIPC)
                : base(new HostOptions
                {
                    Name = hostname,
                    BindIPC = bindIPC,
                })
            {
            }
        }

        private class TestTestGame : TestGame
        {
            public bool IsRootAlive;

            protected override void LoadComplete()
            {
                IsRootAlive = ((TestHeadlessGameHost)Host).CurrentRoot.IsAlive;
                Exit();
            }
        }
    }
}
